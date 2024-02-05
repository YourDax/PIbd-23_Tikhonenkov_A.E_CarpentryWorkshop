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
    public interface IWoodStorage
    {
        List<WoodViewModel> GetFullList();
        List<WoodViewModel> GetFilteredList(WoodSearchModel model);
        WoodViewModel? GetElement(WoodSearchModel model);
        WoodViewModel? Insert(WoodBindingModel model);
        WoodViewModel? Update(WoodBindingModel model);
        WoodViewModel? Delete(WoodBindingModel model);
    }
}
