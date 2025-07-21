using SoloGames.Managers;
using SoloGames.UI;
using Zenject;

namespace SoloGames.DI
{
    public class UISceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UIPopupManager>().FromComponentInHierarchy().AsSingle();
        }
    }
}
