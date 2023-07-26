using UnityEngine;
using System.Collections;

namespace SportsMaze
{
    public class CountdownTimer : MonoBehaviour
    {
        private float countdownDuration;
        private float currentTime;

        #region Properties
        public float CurrentTime { get { return currentTime; } }    
        #endregion


        public void StartCountDown(float countdownDuration, System.Action everySecondCallback, System.Action countDownCompleteCalback)
        {
            this.countdownDuration = countdownDuration;
            currentTime = countdownDuration;
            StartCoroutine(PerformCountdown(everySecondCallback, countDownCompleteCalback));
        }
        private IEnumerator PerformCountdown(System.Action everySecondCallback, System.Action countDownCompleteCalback)
        {
            while (currentTime > 0f)
            {
                yield return new WaitForSeconds(1f);
                currentTime -= 1f;
                everySecondCallback?.Invoke();
            }

            // Countdown is complete, handle the event here if needed
            countDownCompleteCalback?.Invoke();
        }
    }
}