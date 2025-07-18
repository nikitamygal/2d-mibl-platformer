using UnityEngine;


namespace SoloGames.Gameplay
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject SpawnPrefab;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            GameObject spawnObject = Instantiate(SpawnPrefab);
            spawnObject.transform.position = transform.position;
        }
    }
}
