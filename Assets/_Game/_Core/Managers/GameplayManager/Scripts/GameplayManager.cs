using SoloGames.UI;
using UnityEngine;

namespace SoloGames.Managers
{
    public class GameplayManager : SingletonPerScene<GameplayManager>
    {

        public virtual void Pause()
        {
            ApplyTimeScale(0);
        }

        public virtual void UnPause()
        {
            ApplyTimeScale(1);
        }
        
        protected virtual void ApplyTimeScale(float newValue)
		{
            Time.timeScale = newValue;
		}
    }
}
