using SoloGames.Cam;
using UnityEngine;
using Zenject;


namespace SoloGames.Gameplay
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject SpawnPrefab;

        private DiContainer _container;
        private CameraFollow _cameraFollow;

        [Inject]
        public void Construct(DiContainer container, CameraFollow cameraFollow)
        {
            _container = container;
            _cameraFollow = cameraFollow;
            Spawn();
        }

        private void Spawn()
        {
            GameObject spawnObject = _container.InstantiatePrefab(SpawnPrefab);
            spawnObject.transform.position = transform.position;
            SetCameraFollowTarget(spawnObject.transform);
        }
        
        private void SetCameraFollowTarget(Transform target)
        {
            _cameraFollow.SetTarget(target);
        }
        
    }
}
