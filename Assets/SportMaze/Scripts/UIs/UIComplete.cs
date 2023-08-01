using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SportsMaze
{
    public class UIComplete : SportsMazeCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button nextBtn;
        [SerializeField] private Button menuBtn;


        [Header("Stars")]
        [SerializeField] private Image[] stars = new Image[3];

        [Header("Sprite")]
        [SerializeField] private Sprite star;
        [SerializeField] private Sprite noStar;


        private void OnEnable()
        {
            GameplayManager.OnWin += LoadStar;
        }

        private void OnDisable()
        {
            GameplayManager.OnWin -= LoadStar;
        }

        private void Start()
        {
            nextBtn.onClick.AddListener(() =>
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
            nextBtn.onClick.RemoveAllListeners();
            menuBtn.onClick.RemoveAllListeners();
        }

        private void LoadStar()
        {
            for(int i = 0; i < stars.Length; i++)
            {
                if(i + 1 <= GameplayManager.Instance.Star)
                {
                    stars[i].sprite = star;
                }
                else
                {
                    stars[i].sprite = noStar;
                }
            }
        }
    }
}
