using UnityEngine;
using UnityEngine.UI;

namespace SportsMaze
{
    public class UIMainMenu : SportsMazeCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button startBtn;
        [SerializeField] private Button levelsBtn;
        [SerializeField] private Button exitBtn;


        private void Start()
        {
            startBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.GameplayScene);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            levelsBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayLevelsMenu(true);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            exitBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);
                // Call Application.Quit() to exit the game.
                Application.Quit();

                // For the Unity Editor, this will not quit the application. It will stop the editor's play mode.
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            });
        }

        private void OnDestroy()
        {
            startBtn.onClick.RemoveAllListeners();
            levelsBtn.onClick.RemoveAllListeners();
            exitBtn.onClick.RemoveAllListeners();
        }
    }
}
