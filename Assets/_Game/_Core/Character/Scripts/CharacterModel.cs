using System;
using UnityEngine;

namespace SoloGames.Characters
{
    public class CharacterModel : MonoBehaviour
    {
        [SerializeField] private bool _disableModelOnDeath = true;

        public void DisableModelEvent()
        { 
            if (_disableModelOnDeath)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
