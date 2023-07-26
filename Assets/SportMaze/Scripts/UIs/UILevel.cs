using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SportsMaze
{
    public class UILevel : MonoBehaviour
    {
        public Button levelBtn;
        [SerializeField] private TextMeshProUGUI levelText;

        [Header("Stars")]
        [SerializeField] private Image[] stars = new Image[3];

        [Header("Sprite")]
        [SerializeField] private Sprite star;
        [SerializeField] private Sprite noStart; 
        [SerializeField] private Sprite unlockSprite;
        [SerializeField] private Sprite lockSprite;

        // Data
        private LevelData levelData;

        private void Start()
        {
            levelBtn.onClick.AddListener(() =>
            {
                if (levelData.isLocking) return;
                GameManager.Instance.playingLevelData = levelData;
                GameManager.Instance.currentLevel = levelData.level;
                Loader.LoadLevel(levelData.level);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }


        private void OnDestroy()
        {
            levelBtn.onClick.RemoveAllListeners();
        }

        public void SetLevelText(int level)
        {

        }

        public void SetStars(int value)
        {
            if(value > 3) value = 3;
            if (value <= 0) value = 0;

            for(int i = 0; i < stars.Length; i++)
            {
                if(i < value)
                    stars[i].sprite = star;
                else
                    stars[i].sprite = noStart;  
            }
        }

      

        public void UpdateUI(LevelData levelData)
        {
            levelBtn.image.sprite = lockSprite;
            this.levelData = levelData;
            levelText.text = $"{this.levelData.level}";

            if (levelData.isLocking)
                Lock();
            else
                UnLock();
        }

        public void Lock()
        {
            levelBtn.image.sprite = lockSprite;
            levelText.gameObject.SetActive(false);
        }

        public void UnLock()
        {
            levelBtn.image.sprite = unlockSprite;
            levelText.gameObject.SetActive(true);
        }
    }
}
