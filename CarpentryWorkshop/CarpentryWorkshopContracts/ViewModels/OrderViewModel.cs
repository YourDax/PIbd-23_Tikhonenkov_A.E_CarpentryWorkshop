using CarpentryWorkshopDataModels.Enums;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        public int WoodId { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        [DisplayName("Фамилия клиента")]
        public string ClientFIO { get; set; } = string.Empty;

        [DisplayName("Фамилия исполнителя")]
        public string ImplementerFIO { get; set; } = string.Empty;

        [DisplayName("Изделие")]
        public string WoodName { get; set; } = string.Empty;
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public double Sum { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
