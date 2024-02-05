using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopContracts.StoragesContracts
{
    public interface IComponentStorage
    {
        List<ComponentViewModel> GetFullList();
        List<ComponentViewModel> GetFilteredList(ComponentSearchModel model);
        ComponentViewModel? GetElement(ComponentSearchModel model);
        ComponentViewModel? Insert(ComponentBindingModel model);
        ComponentViewModel? Update(ComponentBindingModel model);
        ComponentViewModel? Delete(ComponentBindingModel model);
    }
}
