using UnityEngine;

namespace SoloGames.Managers
{
    public class GameplayManager : SingletonPerScene<GameplayManager>
    {

        public virtual void Pause()
        {
            GUIManager.Instance.SetPausePanel(true);
            ApplyTimeScale(0);
        }

        public virtual void UnPause()
        {
            GUIManager.Instance.SetPausePanel(false);
            ApplyTimeScale(1);
        }
        
        protected virtual void ApplyTimeScale(float newValue)
		{
            Time.timeScale = newValue;
		}
    }
}
