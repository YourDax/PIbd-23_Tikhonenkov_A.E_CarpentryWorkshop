using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using Microsoft.Extensions.Logging;

namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;
        private readonly IShopStorage _shopStorage;
        private readonly IWoodStorage _woodStorage;

        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage, IWoodStorage woodStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
            _woodStorage = woodStorage;
        }

        public List<ShopViewModel> ReadList(ShopSearchModel model)
        {
            _logger.LogInformation("ReadList. ShopName:{ShopName}.Id:{ Id}", model?.ShopName, model?.Id);
            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public bool MakeSupply(SupplyBindingModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentException("Количество изделий должно быть больше 0");
            }
            var shop = _shopStorage.GetElement(new ShopSearchModel
            {
                Id = model.ShopId
            });
            if (shop == null)
            {
                throw new ArgumentException("Магазина не существует");
            }
            if (shop.ShopWoods.ContainsKey(model.WoodId))
            {
                var oldValue = shop.ShopWoods[model.WoodId];
                oldValue.Item2 += model.Count;
                shop.ShopWoods[model.WoodId] = oldValue;
            }
            else
            {
                var wood = _woodStorage.GetElement(new WoodSearchModel
                {
                    Id = model.WoodId
                });
                if (wood == null)
                {
                    throw new ArgumentException($"Поставка: Товар с id:{model.WoodId} не найденн");
                }
                shop.ShopWoods.Add(model.WoodId, (wood, model.Count));
            }
            return true;
        }

        public ShopViewModel ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ShopName:{ShopName}.Id:{ Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                throw new ArgumentException("Адрес магазина длжен быть заполнен", nameof(model.Address));
            }
            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentException("Название магазина должно быть заполнено", nameof(model.ShopName));
            }
            _logger.LogInformation("Shop. ShopName:{ShopName}.Adres:{Adres}.OpeningDate:{OpeningDate}.Id:{ Id}", model.ShopName, model.Address, model.DateOpen, model.Id);
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }
        public bool Sale(SupplySearchModel model)
        {
            if (!model.WoodId.HasValue || !model.Count.HasValue)
            {
                return false;
            }
            _logger.LogInformation("Check pizza count in all shops");
            if (_shopStorage.Sale(model))
            {
                _logger.LogInformation("Selling sucsess");
                return true;
            }
            _logger.LogInformation("Selling failed");
            return false;
        }
    }
}
