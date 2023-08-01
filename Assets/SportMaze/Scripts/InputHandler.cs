using UnityEngine;

namespace SportsMaze
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance { get; private set; }
        public static event System.Action OnReleaseMouseButton;
        public static event System.Action OnMouseButtonNotChange;
        
        public Transform centerPoint;

        // Cached
        private Camera mainCam;


        public bool IsPressing { get; private set; } = false;
        public bool IsClockwise { get; private set; } = false;

    
        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            mainCam = Camera.main;

            if (centerPoint == null)
            {
                Debug.LogError("Center point is not assigned!");
            }

        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                IsPressing = true;
                var mousePosition = GetMousePosition();
                if (mousePosition.x < centerPoint.position.x)
                {
                    // Left mouse button was clicked on the left side of the object
                    IsClockwise = false;
                }
                else
                {
                    // Right mouse button was clicked on the right side of the object
                    IsClockwise = true;
                }
            }
            else
            {
                IsPressing = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnReleaseMouseButton?.Invoke();
            }
        }

        private Vector2 GetMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCam.transform.position.z;
            return mainCam.ScreenToWorldPoint(mousePos);
        }

    }
}