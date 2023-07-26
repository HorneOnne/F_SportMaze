using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SportsMaze
{
    public class UIGameplay : SportsMazeCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button backBtn;
        [SerializeField] private Button soundFXBtn;

        [Space(10)]
        [SerializeField] private TextMeshProUGUI timerText;


        [Header("Sprites")]
        [SerializeField] private Sprite unmuteSoundSprite;
        [SerializeField] private Sprite muteSoundSprite;
        private void Start()
        {
            UpdateSoundFXUI();

            backBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MainmenuScene);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            soundFXBtn.onClick.AddListener(() =>
            {
                ToggleSFX();
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void Update()
        {
            timerText.text = GameplayManager.Instance.countDownTimer.CurrentTime.ToString();
        }


        private void ToggleSFX()
        {

            SoundManager.Instance.MuteSoundFX(SoundManager.Instance.isSoundFXActive);
            SoundManager.Instance.isSoundFXActive = !SoundManager.Instance.isSoundFXActive;

            UpdateSoundFXUI();
        }
        private void UpdateSoundFXUI()
        {
            if (SoundManager.Instance.isSoundFXActive)
            {
                soundFXBtn.image.sprite = unmuteSoundSprite;
            }
            else
            {
                soundFXBtn.image.sprite = muteSoundSprite;
            }
        }


        private void OnDestroy()
        {
            backBtn.onClick.RemoveAllListeners();
            soundFXBtn.onClick.RemoveAllListeners();
        }
    }
}
