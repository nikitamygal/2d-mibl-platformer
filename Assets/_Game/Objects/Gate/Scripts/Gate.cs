using UnityEngine;

namespace SoloGames.Gameplay
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private bool _isOpen = false;
        private string _openParameter = "Open";
        private string _tagToOpen = "Shot";

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isOpen && other.tag == _tagToOpen)
            {
                OpenGate();
            }
        }

        private void OpenGate()
        {
            _isOpen = true;
            if (_animator != null)
            {
                _animator.SetTrigger(_openParameter);
            }
        }
    }
}
