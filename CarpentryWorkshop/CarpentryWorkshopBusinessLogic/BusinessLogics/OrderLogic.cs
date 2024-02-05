using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
        }
        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("ReadList. Id:{ Id}", model?.Id);
            var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public bool CreateOrder(OrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                WoodId = model.WoodId,
                WoodName = model.WoodName,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят,
                DateCreate = DateTime.Now
            }); ;
            return true;
        }
        public bool TakeOrderInWork(OrderBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderSearchModel
            {
                Id = model.Id
            });
            if (order == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (order.Status.ToString() != "Принят")
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                WoodId = order.WoodId,
                WoodName = order.WoodName,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                
                Status = OrderStatus.Выполняется
            });
            return true;
        }
        public bool FinishOrder(OrderBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderSearchModel
            {
                Id = model.Id
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status.ToString() != "Выполняется")
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                WoodId = order.WoodId,
                WoodName = order.WoodName,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Готов
            });
            return true;
        }
        public bool DeliveryOrder(OrderBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderSearchModel
            {
                Id = model.Id
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status.ToString() != "Готов")
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                WoodId = order.WoodId,
                WoodName = order.WoodName,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Выдан
            });
            return true;
        }
    }
}
