using CarpentryWorkshopContracts.DI;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopDatabaseImplement.Implements;

namespace CarpentryWorkshopDatabaseImplement
{
    public class ImplementationExtension : IImplementationExtension
    {
        public int Priority => 3;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();
            DependencyManager.Instance.RegisterType<IComponentStorage, ComponentStorage>();
            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();
            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();
            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();
            DependencyManager.Instance.RegisterType<IWoodStorage, WoodStorage>();
            DependencyManager.Instance.RegisterType<IBackUpInfo, BackUpInfo>();
        }
    }
}
