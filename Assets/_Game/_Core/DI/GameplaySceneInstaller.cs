using SoloGames.Cam;
using SoloGames.Configs;
using SoloGames.Managers;
using UnityEngine;
using Zenject;

namespace SoloGames.DI
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelListSO _levelListSO;

        public override void InstallBindings()
        {
            Container.Bind<GameplayManager>().FromNew().AsSingle();
            Container.Bind<InputManager>().FromNew().AsSingle();
            Container.Bind<LevelListSO>().FromInstance(_levelListSO).AsSingle();
            Container.Bind<LevelManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CameraFollow>().FromComponentInHierarchy().AsSingle();
        }
    }
}
