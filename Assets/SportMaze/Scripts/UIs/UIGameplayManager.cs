using UnityEngine;

namespace SportsMaze
{
    public class UIGameplayManager : MonoBehaviour
    {
        public static UIGameplayManager Instance { get; private set; }

        public UIComplete uiComplete;
        public UITimeout uiTimeout;



        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
        }

        public void CloseAll()
        {
            DisplayCompleteMenu(false);
            DisplayTimeoutMenu(false);

        }

        public void DisplayCompleteMenu(bool isActive)
        {
            uiComplete.DisplayCanvas(isActive);
        }

        public void DisplayTimeoutMenu(bool isActive)
        {
            uiTimeout.DisplayCanvas(isActive);
        }
    }
}
