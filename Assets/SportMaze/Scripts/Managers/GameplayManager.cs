using UnityEngine;

namespace SportsMaze
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }
        public static event System.Action OnStateChanged;
        public static event System.Action OnPlaying;
        public static event System.Action OnWin;
        public static event System.Action OnGameOver;

        public enum GameState
        {
            START,
            PLAYING,
            WIN,
            GAMEOVER,
            PAUSE,
        }


        [Header("Properties")]
        public GameState currentState;
        [SerializeField] private float waitTimeBeforePlaying = 0.5f;
        [SerializeField] private float gameplayTime = 15f;
        public int Star { get; set; } = 0;


        [Header("References")]
        public CountdownTimer countDownTimer;




        private void Awake()
        {
            Instance = this;
            Time.timeScale = 1.0f;
        }

        private void OnEnable()
        {
            OnStateChanged += SwitchState;
        }

        private void OnDisable()
        {
            OnStateChanged -= SwitchState;
        }

        private void Start()
        {
            ChangeGameState(GameState.START);

        }

     

        public void ChangeGameState(GameState state)
        {
            currentState = state;
            OnStateChanged?.Invoke();
        }

        private void SwitchState()
        {
            switch(currentState)
            {
                default: break;
                case GameState.START:
               
                    countDownTimer.StartCountDown(gameplayTime, null, CountDownComplete);
                    ChangeGameState(GameState.PLAYING);
                    break;
                case GameState.PLAYING:
        
                    break;
                case GameState.WIN:
                    SoundManager.Instance.PlaySound(SoundType.Win, false);
                    Star = CalculateStar();
                    Time.timeScale = 0.0f;
                    StartCoroutine(Utilities.WaitAfterRealtime(1.0f, () =>
                    {
                        // UI
                        UIGameplayManager.Instance.CloseAll();
                        UIGameplayManager.Instance.DisplayCompleteMenu(true);
                        Time.timeScale = 1.0f;
                    }));

                    GameManager.Instance.SetStar(Star);
                    GameManager.Instance.NextLevel();
                    OnWin?.Invoke();
                    break;
                case GameState.GAMEOVER:
                    SoundManager.Instance.PlaySound(SoundType.GameOver, false);
                    Time.timeScale = 0.0f;
                    
                    StartCoroutine(Utilities.WaitAfterRealtime(1.0f, () =>
                    {
                        // UI
                        UIGameplayManager.Instance.CloseAll();
                        UIGameplayManager.Instance.DisplayTimeoutMenu(true);
                        Time.timeScale = 1.0f;
                    }));
                    OnGameOver?.Invoke();   
                    break;
                case GameState.PAUSE:
                    break;
            }

        }

        private void CountDownComplete()
        {
            if (currentState == GameState.PLAYING)
                ChangeGameState(GameState.GAMEOVER);
        }
        private int CalculateStar()
        {
            if(countDownTimer.CurrentTime > 10)
            {
                return 3;
            }
            else if (countDownTimer.CurrentTime > 5)
            {
                return 2;
            }
            else if (countDownTimer.CurrentTime > 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }       
}
