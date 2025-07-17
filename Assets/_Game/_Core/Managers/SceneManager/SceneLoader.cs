using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoloGames.Managers
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
