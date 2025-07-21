using UnityEngine.SceneManagement;

namespace SoloGames.Managers
{
    public class SceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
