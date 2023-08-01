using UnityEngine;
using System.Collections;

namespace SportsMaze
{
    public class RotateObjectWithPhysics : MonoBehaviour
    {
        public float linearSpeed = 2f; // Adjust the linear movement speed.
        private Rigidbody2D rb;
        private InputHandler inputHandler;
        [SerializeField] private float maxAngularVelocity = 300f;

        private void OnEnable()
        {
            InputHandler.OnReleaseMouseButton += StopRotate;
            InputHandler.OnMouseButtonNotChange += StopRotate;
        }

        private void OnDisable()
        {
            InputHandler.OnReleaseMouseButton -= StopRotate;
            InputHandler.OnMouseButtonNotChange -= StopRotate;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            inputHandler = InputHandler.Instance;
        }


        private float currentTorque;
        private bool isStopping = false;


        private void StopRotate()
        {
            currentTorque = rb.angularVelocity;
            if (!isStopping)
                StartCoroutine(SmoothStopTorque(1.0f));
        }

        private IEnumerator SmoothStopTorque(float stopTime)
        {
            isStopping = true;
            float elapsedTime = 0f;

            while (elapsedTime < stopTime)
            {
                float t = elapsedTime / stopTime;
                
                rb.angularVelocity = Mathf.Lerp(currentTorque, 0f, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

         
            rb.angularVelocity = 0f;
            isStopping = false;
            rb.freezeRotation = true;
        }

     
        private void FixedUpdate()
        {
            if (inputHandler.isDragging)
            {
                rb.freezeRotation = false;
                if(inputHandler.isClockwise)
                    rb.AddTorque(linearSpeed, ForceMode2D.Force);      
                else
                    rb.AddTorque(-linearSpeed, ForceMode2D.Force);

                if (rb.angularVelocity > maxAngularVelocity)
                    rb.angularVelocity = maxAngularVelocity;

                if (rb.angularVelocity < -maxAngularVelocity)
                    rb.angularVelocity = -maxAngularVelocity;
            }                       
        }
    }
}