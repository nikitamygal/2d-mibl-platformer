using UnityEngine;

namespace SoloGames.Cam
{

    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothTime = 0.25f;
        [SerializeField] private Vector3 _offset = new Vector3(0f, 0f, -10f);

        private Vector3 _velocity = Vector3.zero;
        
        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void FollowTarget()
        {
            if (_target == null) return;
            transform.position = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _velocity, _smoothTime);
        }

        private void Update()
        {
            FollowTarget();
        }
        
    }
}
