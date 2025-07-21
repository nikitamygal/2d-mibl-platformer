using SoloGames.Managers;
using SoloGames.SaveLoad;
using Zenject;

namespace SoloGames.DI
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SaveSystem>().FromNew().AsSingle();
            Container.Bind<SceneLoader>().FromNew().AsSingle();
        }
    }
}
