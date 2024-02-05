using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopContracts.BusinessLogicsContracts
{
    public interface IComponentLogic
    {
        List<ComponentViewModel>? ReadList(ComponentSearchModel? model);
        ComponentViewModel? ReadElement(ComponentSearchModel model);
        bool Create(ComponentBindingModel model);
        bool Update(ComponentBindingModel model);
        bool Delete(ComponentBindingModel model);
    }

}
