using CarpentryWorkshopFileImplement.Models;
using System.Xml.Linq;

namespace CarpentryWorkshopFileImplement
{
    public class DataFileSingleton
    {
        private static DataFileSingleton? instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string WoodFileName = "Wood.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageFileName = "Message.xml";
        public List<Message> Messages { get; private set; }
        public List<Component> Components { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<Wood> Woods { get; private set; }
        public List<Client> Clients { get; private set; }
        public List<Implementer> Implementers { get; private set; }
        public static DataFileSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataFileSingleton();
            }
            return instance;
        }
        public void SaveComponents() => SaveData(Components, ComponentFileName, "Components", x => x.GetXElement);
        public void SaveWoods() => SaveData(Woods, WoodFileName, "Woods", x => x.GetXElement);
        public void SaveOrders() => SaveData(Orders, OrderFileName, "Orders", x => x.GetXElement);
        public void SaveClients() => SaveData(Clients, ClientFileName, "Clients", x => x.GetXElement);
        public void SaveMessages() => SaveData(Messages, MessageFileName, "Messages", x => x.GetXElement);

        public void SaveImplementers() => SaveData(Implementers, ImplementerFileName, "Implementers", x => x.GetXElement);
        private DataFileSingleton()
        {
            Components = LoadData(ComponentFileName, "Component", x => Component.Create(x)!)!;
            Woods = LoadData(WoodFileName, "Wood", x => Wood.Create(x)!)!;
            Orders = LoadData(OrderFileName, "Order", x => Order.Create(x)!)!;
            Clients = LoadData(ClientFileName, "Client", x => Client.Create(x)!)!;
            Implementers = LoadData(ImplementerFileName, "Implementer", x => Implementer.Create(x)!)!;
            Messages = LoadData(MessageFileName, "Message", x => Message.Create(x)!)!;
        }
        private static List<T>? LoadData<T>(string filename, string xmlNodeName, Func<XElement, T> selectFunction)
        {
            if (File.Exists(filename))
            {
                return XDocument.Load(filename)?.Root?.Elements(xmlNodeName)?.Select(selectFunction)?.ToList();
            }
            return new List<T>();
        }
        private static void SaveData<T>(List<T> data, string filename, string xmlNodeName, Func<T, XElement> selectFunction)
        {
            if (data != null)
            {
                new XDocument(new XElement(xmlNodeName, data.Select(selectFunction).ToArray())).Save(filename);
            }
        }

    }
}