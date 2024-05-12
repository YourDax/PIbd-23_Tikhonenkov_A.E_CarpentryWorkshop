using CarpentryWorkshopContracts.DI;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopListImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopListImplement
{
    internal class ImplementationExtension : IImplementationExtension
    {
        public int Priority => 0;

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
