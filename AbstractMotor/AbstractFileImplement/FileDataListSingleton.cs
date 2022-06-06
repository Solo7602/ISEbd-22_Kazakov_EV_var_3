using AbstructFactoryContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryFileImplement.Models;
using System.IO;

namespace AbstractFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string DetailFileName = "Detail.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string EngineFileName = "Engine.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        public List<Details> Details { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Engines> Engines { get; set; }
        public List<Clients> Clients { get; set; }
        public List<Implementers> Implementers { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Engines = LoadEngines();
            Clients = LoadClients();
            Implementers = LoadImplementers();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        public static void SaveAll()
        {
            GetInstance().SaveDetails();
            GetInstance().SaveOrders();
            GetInstance().SaveEngines();
            GetInstance().SaveClients();
            GetInstance().SaveImplementers();
        }
        private List<Details> LoadDetails()
        {
            var list = new List<Details>();
            if (File.Exists(DetailFileName))
            {
                var xDocument = XDocument.Load(DetailFileName);
                var xElements = xDocument.Root.Elements("Detail").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Details
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DetailName = elem.Element("DetailName").Value
                    });
                }
            }
            return list;
        }
        private List<Orders> LoadOrders()
        {
            var list = new List<Orders>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Orders
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EngineId = Convert.ToInt32(elem.Element("EngineId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Engines> LoadEngines()
        {
            var list = new List<Engines>();
            if (File.Exists(EngineFileName))
            {
                var xDocument = XDocument.Load(EngineFileName);
                var xElements = xDocument.Root.Elements("Engine").ToList();
                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("EngineDetail").Elements("EngineDetail").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Engines
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EngineName = elem.Element("EngineName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        EngineDetails = prodComp
                    });
                }
            }
            return list;
        }
        private List<Clients> LoadClients()
        {
            var list = new List<Clients>();

            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();

                foreach (var client in xElements)
                {
                    list.Add(new Clients
                    {
                        Id = Convert.ToInt32(client.Attribute("Id").Value),
                        ClientFIO = client.Element("ClientFIO").Value,
                        Email = client.Element("Email").Value,
                        Password = client.Element("Password").Value,
                    });
                }
            }
            return list;
        }
        private List<Implementers> LoadImplementers()
        {
            var list = new List<Implementers>();

            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Implementers
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value),
                    });
                }
            }
            return list;
        }
        private void SaveDetails()
        {
            if (Details != null)
            {
                var xElement = new XElement("Details");
                foreach (var detail in Details)
                {
                    xElement.Add(new XElement("Detail",
                    new XAttribute("Id", detail.Id),
                    new XElement("DetailName", detail.DetailName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(DetailFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                XElement xElement = new XElement("Orders");
                foreach (Orders order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("EngineId", order.EngineId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveEngines()
        {
            if (Engines != null)
            {
                var xElement = new XElement("Engines");
                foreach (var engine in Engines)
                {
                    var detElement = new XElement("EngineDetail");
                    foreach (var detail in engine.EngineDetails)
                    {
                        detElement.Add(new XElement("EngineDetail",
                        new XElement("Key", detail.Key),
                        new XElement("Value", detail.Value)));
                    }
                    xElement.Add(new XElement("Engine",
                     new XAttribute("Id", engine.Id),
                     new XElement("EngineName", engine.EngineName),
                     new XElement("Price", engine.Price),
                     detElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(EngineFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");

                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
    }
}
