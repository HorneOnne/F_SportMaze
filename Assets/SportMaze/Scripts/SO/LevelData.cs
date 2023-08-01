using UnityEngine;

namespace SportsMaze
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "SportsMaze/LevelData", order = 51)]
    public class LevelData : ScriptableObject
    {
        [Header("Level")]
        public int level;
        public int star;
        public bool isLocking;

        public GameObject mapPrefab;
        public Vector2 ballPosition;
    }
}
