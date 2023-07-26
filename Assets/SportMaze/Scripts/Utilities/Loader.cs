using UnityEngine.SceneManagement;

namespace SportsMaze
{
    public static class Loader
    {
        public enum Scene
        {
            MainmenuScene,
            Level_01,
        }

        private static Scene targetScene;

        public static void Load(Scene targetScene, System.Action afterLoadScene = null)
        {
            Loader.targetScene = targetScene;
            SceneManager.LoadScene(Loader.targetScene.ToString());
        }

        public static void LoadLevel(int level, System.Action afterLoadScene = null)
        {
            Loader.targetScene = GetSceneLevel(level);
            SceneManager.LoadScene(targetScene.ToString());
        }

        public static Scene GetSceneLevel(int level)
        {
            switch (level)
            {
                default: return Scene.Level_01;
                case 1: return Scene.Level_01;
                case 2: return Scene.Level_01;
                case 3: return Scene.Level_01;
                case 4: return Scene.Level_01;
                case 5: return Scene.Level_01;
                case 6: return Scene.Level_01;
                case 7: return Scene.Level_01;
                case 8: return Scene.Level_01;
                case 9: return Scene.Level_01;
            }
        }
    }
}
