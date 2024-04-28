using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
	public class MessageInfoStorage : IMessageInfoStorage
	{
		public List<MessageInfoViewModel> GetFullList()
		{
			using var context = new CarpentryWorkshopDatabase();
			return context.MessageInfos.Select(x => x.GetViewModel).ToList();
		}
		public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
		{
			if (!model.ClientId.HasValue)
			{
				return new();
			}
			using var context = new CarpentryWorkshopDatabase();
			return context.MessageInfos.Where(x => x.ClientId.HasValue && x.ClientId == model.ClientId).Select(x => x.GetViewModel).ToList();
		}
		public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
		{
			if (string.IsNullOrEmpty(model.MessageId))
			{
				return new();
			}
			using var context = new CarpentryWorkshopDatabase();
			return context.MessageInfos.FirstOrDefault(x => x.MessageId == model.MessageId)?.GetViewModel;
		}
		public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
		{
			var newMessage = MessageInfo.Create(model);
			if (newMessage == null)
			{
				return null;
			}
			using var context = new CarpentryWorkshopDatabase();
			context.MessageInfos.Add(newMessage);
			context.SaveChanges();
			return newMessage.GetViewModel;
		}
		public MessageInfoViewModel? Update(MessageInfoBindingModel model)
		{
			using var context = new CarpentryWorkshopDatabase();
			var component = context.MessageInfos.FirstOrDefault(x => x.MessageId == model.MessageId);
			if (component == null)
			{
				return null;
			}
			component.Update(model);
			context.SaveChanges();
			return component.GetViewModel;
		}
	}
}
