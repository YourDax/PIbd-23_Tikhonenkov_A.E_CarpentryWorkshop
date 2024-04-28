using CarpentryWorkshopBusinessLogic.MailWorker;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractMailWorker _mailWorker;
        private readonly IClientLogic _clientLogic;

        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage, AbstractMailWorker mailWorker, IClientLogic clientLogic)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _mailWorker = mailWorker;
            _clientLogic = clientLogic;
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
            var result = _orderStorage.Insert(model);

            if (result == null)
            {
                model.Status = OrderStatus.Неизвестен;
                _logger.LogWarning("Insert operation failed");
                return false;
            }

            SendOrderMessage(result.ClientId, $"Установка ПО, Заказ №{result.Id}", $"Заказ №{result.Id} от {result.DateCreate} на сумму {result.Sum:0.00} принят");

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

            var result = _orderStorage.Update(model);

            if (result == null)
            {
                _logger.LogWarning("Update operation failed");

                return false;
            }


            SendOrderMessage(result.ClientId, $"Установка ПО, Заказ №{result.Id}", $"Заказ №{model.Id} изменен статус на {result.Status}");
            return true;
        }

        private bool SendOrderMessage(int clientId, string subject, string text)
        {
            var client = _clientLogic.ReadElement(new() { Id = clientId });

            if (client == null)
            {
                return false;
            }

            _mailWorker.MailSendAsync(new()
            {
                MailAddress = client.Email,
                Subject = subject,
                Text = text
            });

            return true;
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return StatusUpdate(model, OrderStatus.Выполняется);
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            model.DateImplement = DateTime.Now;
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

        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.WoodId < 0)
            {
                throw new ArgumentNullException("Некорректный идентификатор у изделия", nameof(model.WoodId));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentNullException("Количество изделий в заказе должно быть больше 0", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentNullException("Сумма заказа должна быть больше 0", nameof(model.Sum));
            }
            _logger.LogInformation("Order. OrderID:{Id}. Sum:{ Sum}. WoodId: { WoodId}", model.Id, model.Sum, model.WoodId);
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
