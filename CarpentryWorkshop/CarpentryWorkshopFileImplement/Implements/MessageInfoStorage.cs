using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopFileImplement.Models;

namespace CarpentryWorkshopFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataFileSingleton source;
        public MessageInfoStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            if (model.MessageId == null)
                return null;
            return source.Messages.FirstOrDefault(x => 
            x.MessageId == model.MessageId)?.GetViewModel;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            if (!model.ClientId.HasValue)
            {
                return new();
            }
            return source.Messages
                .Where(x => x.ClientId == model.ClientId)
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            return source.Messages
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            var newMessage = Message.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            source.Messages.Add(newMessage);
            source.SaveMessages();
            return newMessage.GetViewModel;
        }
		public MessageInfoViewModel? Update(MessageInfoBindingModel model)
		{
			var component = source.Messages.FirstOrDefault(x => x.MessageId == model.MessageId);
			if (component == null)
			{
				return null;
			}
			component.Update(model);
			source.SaveMessages();
			return component.GetViewModel;
		}
	}
}
