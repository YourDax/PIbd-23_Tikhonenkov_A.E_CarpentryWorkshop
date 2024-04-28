using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;

namespace CarpentryWorkshopListImplement.Models
{
    public class Message : IMessageInfoModel
    {
        public string MessageId { get; private set; } = string.Empty;

        public int? ClientId { get; private set; }

        public string SenderName { get; private set; } = string.Empty;

        public DateTime DateDelivery { get; private set; } = DateTime.Now;

        public string Subject { get; private set; } = string.Empty;

        public string Body { get; private set; } = string.Empty;

        public static Message? Create(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new()
            {
                Body = model.Body,
                Subject = model.Subject,
                DateDelivery = model.DateDelivery,
                SenderName = model.SenderName,
                ClientId = model.ClientId,
                MessageId = model.MessageId
            };
        }
		public void Update(MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			SenderName = model.SenderName;
			DateDelivery = model.DateDelivery;
			Subject = model.Subject;
			Body = model.Body;
		}
		public MessageInfoViewModel GetViewModel => new()
        {
            Body = Body,
            Subject = Subject,
            DateDelivery = DateDelivery,
            SenderName = SenderName,
            ClientId = ClientId,
            MessageId = MessageId
        };
    }
}
