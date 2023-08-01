using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SportsMaze
{
    public class UITimeout : SportsMazeCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button restartBtn;
        [SerializeField] private Button menuBtn;


        private void Start()
        {
            restartBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.GameplayScene);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            menuBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MainmenuScene);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            restartBtn.onClick.RemoveAllListeners();
            menuBtn.onClick.RemoveAllListeners();
        }
    }
}
