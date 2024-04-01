using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;

namespace CarpentryWorkshopContracts.BusinessLogicsContracts
{
    public interface IShopLogic
    {
        List<ShopViewModel>? ReadList(ShopSearchModel? model);
        ShopViewModel? ReadElement(ShopSearchModel model);
        bool Create(ShopBindingModel model);
        bool Update(ShopBindingModel model);
        bool Delete(ShopBindingModel model);
        bool MakeSupply(SupplyBindingModel model);
    }
}
