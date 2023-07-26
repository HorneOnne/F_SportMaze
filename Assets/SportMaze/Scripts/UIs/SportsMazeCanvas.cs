using UnityEngine;

namespace SportsMaze
{
    public class SportsMazeCanvas : MonoBehaviour
    {
        [SerializeField] protected Canvas _canvas;

        #region Properties
        public Canvas Canvas { get { return _canvas; } }
        #endregion

        public void DisplayCanvas(bool isDisplay)
        {
            _canvas.enabled = isDisplay;
        }
    }
}
