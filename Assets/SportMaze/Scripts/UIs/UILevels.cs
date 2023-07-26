using UnityEngine;
using UnityEngine.UI;

namespace SportsMaze
{
    public class UILevels : SportsMazeCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button backBtn;

        [Header("Levels")]
        [SerializeField] private UILevel uiLevelPrefab;
        [SerializeField] private Transform levelRoot;



        private void Start()
        {
            LoadLevelUI();

            backBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplayMainMenu(true);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

 
        }

        private void OnDestroy()
        {
            backBtn.onClick.RemoveAllListeners();
        }

        private void LoadLevelUI()
        {
            for (int i = 0; i < GameManager.Instance.TotalGameLevel; i++)
            {
                UILevel uiLevel = Instantiate(uiLevelPrefab, levelRoot);
                uiLevel.UpdateUI(GameManager.Instance.levelData[i]);
                uiLevel.SetStars(GameManager.Instance.levelData[i].star);

            }
        }
    }
}
