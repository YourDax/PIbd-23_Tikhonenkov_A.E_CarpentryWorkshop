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
    public interface IWoodLogic
    {
        List<WoodViewModel>? ReadList(WoodSearchModel? model);
        WoodViewModel? ReadElement(WoodSearchModel model);
        bool Create(WoodBindingModel model);
        bool Update(WoodBindingModel model);
        bool Delete(WoodBindingModel model);
    }
}
