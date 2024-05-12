using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace CarpentryWorkshopFileImplement.Models
{
    [DataContract]
    public class Message : IMessageInfoModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string MessageId { get; private set; } = string.Empty;

        [DataMember]
        public int? ClientId { get; private set; }

        [DataMember]
        public string SenderName { get; private set; } = string.Empty;

        [DataMember]
        public DateTime DateDelivery { get; private set; }

        [DataMember]
        public string Subject { get; private set; } = string.Empty;

        [DataMember]
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

        public static Message? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new()
            {
                Body = element.Attribute("Body")!.Value,
                Subject = element.Attribute("Subject")!.Value,
                DateDelivery = Convert.ToDateTime(element.Attribute("DateDelivery")!.Value),
                SenderName = element.Attribute("SenderName")!.Value,
                ClientId = Convert.ToInt32(element.Attribute("ClientId")!.Value),
                MessageId = element.Attribute("MessageId")!.Value,
            };
        }

		internal void Update(MessageInfoBindingModel model)
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

        public XElement GetXElement => new("MessageInfo",
            new XAttribute("Subject", Subject),
            new XAttribute("Body", Body),
            new XAttribute("ClientId", ClientId),
            new XAttribute("MessageId", MessageId),
            new XAttribute("SenderName", SenderName),
            new XAttribute("DateDelivery", DateDelivery)
            );
    }
}
