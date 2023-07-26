using UnityEngine;

namespace SportsMaze
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance { get; private set; }
        public static event System.Action OnReleaseMouseButton;
        public static event System.Action OnMouseButtonNotChange;

        public Transform centerPoint;
        public float thresholdAngle = 0.5f; // Minimum angle change to detect movement
        public float minSpeed = 50f; // Minimum speed to consider it as movement

        private float previousAngle;
        private float previousTime;

        public bool isDragging = false;
        public bool isClockwise = false;

        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            if (centerPoint == null)
            {
                Debug.LogError("Center point is not assigned!");
            }

            Vector2 centerToMouse = GetMousePosition() - (Vector2)centerPoint.position;
            previousAngle = Mathf.Atan2(centerToMouse.y, centerToMouse.x) * Mathf.Rad2Deg;
            previousTime = Time.time;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {              
                Vector2 centerToMouse = GetMousePosition() - (Vector2)centerPoint.position;
                float currentAngle = Mathf.Atan2(centerToMouse.y, centerToMouse.x) * Mathf.Rad2Deg;

                float angleDiff = currentAngle - previousAngle;
                if (angleDiff > 180f)
                    angleDiff -= 360f;
                else if (angleDiff < -180f)
                    angleDiff += 360f;

                // Calculate the time difference
                float currentTime = Time.time;
                float timeDiff = currentTime - previousTime;

                // Calculate angular speed in degrees per second
                float angularSpeed = angleDiff / timeDiff;

                // Detect clockwise or counterclockwise movement based on the threshold angle and minimum speed
                if (angleDiff > thresholdAngle && angularSpeed > minSpeed)
                {
                    isClockwise = true;
                    isDragging = true;
                    //Debug.Log("Clockwise movement with speed: " + angularSpeed + " degrees per second");
                }
                else if (angleDiff < -thresholdAngle && angularSpeed < -minSpeed)
                {
                    isClockwise = false;
                    isDragging = true;
                    //Debug.Log("Counterclockwise movement with speed: " + angularSpeed + " degrees per second");
                }
                else
                {
                    if(isDragging)
                    {
                        //isDragging = false;
                        //OnMouseButtonNotChange?.Invoke();
                    }                          
                }

                // Update previous angle and time
                previousAngle = currentAngle;
                previousTime = currentTime;
            }
            else
            {
                isDragging = false;
                isDragging = false;
            }

            if(Input.GetMouseButtonUp(0))
            {
                OnReleaseMouseButton?.Invoke();
            }
        }

        private Vector2 GetMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }

    }
}