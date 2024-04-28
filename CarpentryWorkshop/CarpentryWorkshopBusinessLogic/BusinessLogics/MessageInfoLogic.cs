using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopBusinessLogic.BusinessLogics
{
	public class MessageInfoLogic : IMessageInfoLogic
	{
		private readonly ILogger _logger;
		private readonly IMessageInfoStorage _messageInfoStorage;
		public MessageInfoLogic(ILogger<MessageInfoLogic> logger, IMessageInfoStorage messageInfoStorage)
		{
			_logger = logger;
			_messageInfoStorage = messageInfoStorage;
		}

		public bool Create(MessageInfoBindingModel model)
		{
			
			var element = _messageInfoStorage.GetElement(new MessageInfoSearchModel
			{
				MessageId = model.MessageId
			});
			if (element != null)
			{
				if (_messageInfoStorage.Update(model) == null)
				{
					_logger.LogWarning("Update operation failed");
					return false;
				}
				return true;
			}
			else
			{
				if (_messageInfoStorage.Insert(model) == null)
				{
					_logger.LogWarning("Insert operation failed");
					return false;
				}
				return true;
			}
		}

		public List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model)
		{
			_logger.LogInformation("ReadList. ClientId:{ClientId}", model?.ClientId);
			var list = model == null ? _messageInfoStorage.GetFullList() : _messageInfoStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
	}
}
