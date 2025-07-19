using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoloGames.Managers
{
    public class SceneLoader : SingletonPerScene<SceneLoader>
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
