using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopListImplement.Models;

namespace CarpentryWorkshopListImplement.Implements
{
    internal class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton _source;
        public MessageInfoStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            if (model.MessageId == null)
            {
                return null;
            }
            foreach (var message in _source.Messages)
            {
                if (model.MessageId.Equals(message.MessageId))
                    return message.GetViewModel;
            }
            return null;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            if (!model.ClientId.HasValue)
            {
                return new();
            }
            var result = new List<MessageInfoViewModel>();
            foreach (var item in _source.Messages)
            {
                if (item.ClientId == model.ClientId)
                {
                    result.Add(item.GetViewModel);
                }
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            var result = new List<MessageInfoViewModel>();
            foreach (var item in _source.Messages)
            {
                result.Add(item.GetViewModel);
            }
            return result;
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            var newMessage = Message.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            _source.Messages.Add(newMessage);
            return newMessage.GetViewModel;
        }
		public MessageInfoViewModel? Update(MessageInfoBindingModel model)
		{
			foreach (var massage in _source.Messages)
			{
				if (massage.MessageId == model.MessageId)
				{
					massage.Update(model);

					return massage.GetViewModel;
				}
			}
			return null;
		}
	}
}
