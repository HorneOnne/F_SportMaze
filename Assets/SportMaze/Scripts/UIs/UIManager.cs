using UnityEngine;

namespace SportsMaze
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public UIMainMenu uiMainMenu;
        public UILevels uiLevels;
 


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
            DisplayMainMenu(true);
        }

        public void CloseAll()
        {
            DisplayMainMenu(false);
            DisplayLevelsMenu(false);
       
        }

        public void DisplayMainMenu(bool isActive)
        {
            uiMainMenu.DisplayCanvas(isActive);
        }

        public void DisplayLevelsMenu(bool isActive)
        {
            uiLevels.DisplayCanvas(isActive);
        }
    }
}
