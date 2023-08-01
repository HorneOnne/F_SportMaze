using UnityEngine;

namespace SportsMaze
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        [SerializeField] private GameObject ballPrefab;

        // Cached
        private GameManager gameManager;
        private GameObject map;
        private Ball ball;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
            LoadLevel();
        }

        private void LoadLevel()
        {
            // Set the rotation of the prefab to zero (Quaternion.identity)
            Quaternion originalRotation = gameManager.playingLevelData.mapPrefab.transform.rotation;
            map = Instantiate(gameManager.playingLevelData.mapPrefab, transform.position, originalRotation);
            ball = Instantiate(ballPrefab, gameManager.playingLevelData.ballPosition, Quaternion.identity).GetComponent<Ball>();
        }

    }
}
