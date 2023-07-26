using UnityEngine;
using System.Collections;

namespace SportsMaze
{
    public class Ball : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ParticleSystem destroyPs;
        [SerializeField] private SpriteRenderer sr;

        [Header("Layers")]
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private LayerMask obstacleLayer;

        private bool isTweening = false;
        private Transform targetPosition;
        private Vector2 initialPosition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(GameplayManager.Instance.currentState == GameplayManager.GameState.PLAYING)
            {
                if ((targetLayer.value & (1 << collision.gameObject.layer)) != 0)
                {
                    GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.WIN);
                    TweenToTarget(collision.transform);
                }

                if ((obstacleLayer.value & (1 << collision.gameObject.layer)) != 0)
                {
                    SoundManager.Instance.PlaySound(SoundType.Destroyed, false);

                    // PS
                    var destroyPS = Instantiate(destroyPs, transform.position, Quaternion.identity);
                    Destroy(destroyPS.gameObject, 1f);

                    SetVisible(false);
                    GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.GAMEOVER);
                }
            }        
        }

        public float tweenTime = 1.0f;   // Time for the tween to complete (in seconds)

        private void TweenToTarget(Transform target)
        {
            initialPosition = transform.position;
            targetPosition = target;
            if(!isTweening)
                 StartCoroutine(TweenCoroutine());
        }

        private IEnumerator TweenCoroutine()
        {
            isTweening = true;

            float elapsedTime = 0f;

            while (elapsedTime < tweenTime)
            {
                // Calculate the current position based on the lerp progress
                Vector3 currentPosition = Vector3.Lerp(initialPosition, targetPosition.position, elapsedTime / tweenTime);
                transform.position = currentPosition;

                elapsedTime += Time.unscaledDeltaTime;

                yield return null;
            }

            // Ensure we reach the exact target position when the tween is complete
            transform.position = targetPosition.position;
            isTweening = false;
        }

        private void SetVisible(bool isVisible)
        {
            sr.enabled = isVisible;
        }
    }
}