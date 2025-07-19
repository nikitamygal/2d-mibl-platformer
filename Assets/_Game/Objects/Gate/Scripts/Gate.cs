using UnityEngine;

namespace SoloGames.Gameplay
{
    public class Gate : MonoBehaviour
    {
        [Header("Bindings")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider2D _gateCollider;

        private bool _isOpen = false;
        private string _openParameter = "Open";
        private string _tagToOpen = "Shot";

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isOpen && other.tag == _tagToOpen)
            {
                OpenGate();
                DisableCollider();
            }
        }

        private void OpenGate()
        {
            _isOpen = true;
            _animator?.SetTrigger(_openParameter);
        }

        private void DisableCollider()
        {
            if (_gateCollider == null) return;
            _gateCollider.enabled = false;
        }
    }
}
