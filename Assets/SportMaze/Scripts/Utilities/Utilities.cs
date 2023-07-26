using System.Collections;
using UnityEngine;


namespace SportsMaze
{
    public static class Utilities
    {
        public static IEnumerator WaitAfter(float time, System.Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }


        public static IEnumerator WaitAfterRealtime(float time, System.Action callback)
        {
            yield return new WaitForSecondsRealtime(time);
            callback?.Invoke();
        }
    }
}
