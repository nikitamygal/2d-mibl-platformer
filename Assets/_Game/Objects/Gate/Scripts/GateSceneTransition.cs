using SoloGames.Managers;
using SoloGames.SaveLoad;
using UnityEngine;

namespace SoloGames.Gameplay
{
    public enum TransitionType { Forward, Backward }

    public class GateSceneTransition : MonoBehaviour
    {
        [SerializeField] private TransitionType _transition;

        private string _tagToOpen = "Player";

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == _tagToOpen)
            {
                SceneTransition();
            }
        }

        private void SceneTransition()
        {
            int currentLevelIndex = SaveSystem.GetCurrentLevelIndex();
            int nextLevelIndex = _transition == TransitionType.Forward ? currentLevelIndex + 1 : currentLevelIndex - 1;
            if (nextLevelIndex < 0)
                nextLevelIndex = 0;

            SaveSystem.SetCurrentLevelNumber(nextLevelIndex);
            SceneLoader.Instance.LoadScene("GamePlay");
        }
    }
}
