using UnityEngine;

namespace SoloGames.Cam
{
    public class ParallaxLayer : MonoBehaviour
    {
        [SerializeField] private float _rate;

        private Camera _mainCamera;
        private Vector3 _initCameraPos;
        private Vector3 _initPos;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _initCameraPos = _mainCamera.transform.position;
            _initPos = transform.position;
        }

        private void LateUpdate()
        {
            transform.position = _initPos + (_mainCamera.transform.position - _initCameraPos) * _rate;
        }

    }

}
