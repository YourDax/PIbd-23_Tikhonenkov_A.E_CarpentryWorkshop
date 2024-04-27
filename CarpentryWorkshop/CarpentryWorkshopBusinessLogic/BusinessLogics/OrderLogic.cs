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

        public bool CreateOrder(OrderBindingModel model)
        {
            CheckModel(model);

            if (model.Status != OrderStatus.Неизвестен)
            {
                _logger.LogWarning("Insert operation failed. Order status incorrect.");
                return false;
            }

            model.Status = OrderStatus.Принят;

            if (_orderStorage.Insert(model) == null)
            {
                model.Status = OrderStatus.Неизвестен;
                _logger.LogWarning("Insert operation failed");
                return false;
            }

            return true;
        }

        public bool StatusUpdate(OrderBindingModel model, OrderStatus newStatus)
        {
            var vmodel = _orderStorage.GetElement(new() { Id = model.Id });

            if (vmodel == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if ((int)vmodel.Status + 1 != (int)newStatus)
            {
                throw new InvalidOperationException($"Попытка перевести заказ не в следующий статус: " +
                    $"Текущий статус: {vmodel.Status} \n" +
                    $"Планируемый статус: {newStatus} \n" +
                    $"Доступный статус: {(OrderStatus)((int)vmodel.Status + 1)}");
            }

            model.Status = newStatus;
            model.DateCreate = vmodel.DateCreate;

            if (model.DateImplement == null)
                model.DateImplement = vmodel.DateImplement;

            if (vmodel.ImplementerId.HasValue)
                model.ImplementerId = vmodel.ImplementerId;

            model.WoodId = vmodel.WoodId;
            model.Sum = vmodel.Sum;
            model.Count = vmodel.Count;

            if (_orderStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");

                return false;
            }

            return true;
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выполняется);
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            model.DateImplement = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            return StatusUpdate(model, OrderStatus.Готов);
        }

        public bool FinishOrder(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выдан);
        }

        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("Order. OrderId:{Id}", model?.Id);

            var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);

            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }

            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        private bool CheckModel(OrderBindingModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentException("Количество изделий в заказе должно быть больше 0", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentException("Суммарная стоимость заказа должна быть больше 0", nameof(model.Sum));
            }
            if (model.DateCreate > model.DateImplement)
            {
                throw new ArgumentException("Время создания заказа не может быть больше времени его выполнения", nameof(model.DateImplement));
            }

            return true;
        }

        public OrderViewModel? ReadElement(OrderSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            _logger.LogInformation("ReadElement. Id:{ Id}", model.Id);

            var element = _orderStorage.GetElement(model);

            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");

                return null;
            }

            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);

            return element;
        }
    }
}
