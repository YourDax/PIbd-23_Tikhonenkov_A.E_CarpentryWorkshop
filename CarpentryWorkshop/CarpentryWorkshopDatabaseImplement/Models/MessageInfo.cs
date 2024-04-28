using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Models
{
	public class MessageInfo : IMessageInfoModel
	{
		[Key]
		public string MessageId { get; set; } = string.Empty;

		public int? ClientId { get; set; }

		public virtual Client? Client { get; set; }

		public string SenderName { get; set; } = string.Empty;

		public DateTime DateDelivery { get; set; }

		public string Subject { get; set; } = string.Empty;

		public string Body { get; set; } = string.Empty;

		public static MessageInfo? Create(MessageInfoBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				MessageId = model.MessageId,
				ClientId = model.ClientId,
				SenderName = model.SenderName,
				DateDelivery = model.DateDelivery,
				Subject = model.Subject,
				Body = model.Body,

			};
		}
		public void Update(MessageInfoBindingModel model)
		{
			MessageId = model.MessageId;
			ClientId = model.ClientId;
			SenderName = model.SenderName;
			DateDelivery = model.DateDelivery;
			Subject = model.Subject;
			Body = model.Body;
		}
		public MessageInfoViewModel GetViewModel => new()
		{
			MessageId = MessageId,
			ClientId = ClientId,
			SenderName = SenderName,
			DateDelivery = DateDelivery,
			Subject = Subject,
			Body = Body
		};
	}
}
