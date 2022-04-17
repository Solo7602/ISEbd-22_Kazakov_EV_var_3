using AbstructFactoryContracts.Enums;
using _AbstractFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string DetailFileName = "Detail.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string EngineFileName = "Engine.xml";
        private readonly string WareHouseFileName = "WareHouse.xml";
        public List<Details> Details { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Engines> Engines { get; set; }
        public List<WareHouse> WareHouses { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Engines = LoadEngines();
            WareHouses = LoadWareHouses();
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
            GetInstance().SaveWareHouses();
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
                        Detail = elem.Element("DetailName").Value
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
                        ProductId = Convert.ToInt32(elem.Element("EngineId").Value),
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
                        Engine = elem.Element("EngineName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        EngineDetails = prodComp
                    });
                }
            }
            return list;
        }
        private List<WareHouse> LoadWareHouses()
        {
            var list = new List<WareHouse>();
            if (File.Exists(WareHouseFileName))
            {
                var xDocument = XDocument.Load(WareHouseFileName);
                var xElements = xDocument.Root.Elements("WareHouse").ToList();
                foreach (var elem in xElements)
                {
                    var CompComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("WareHouseComponents").Elements("WareHouseComponent").ToList())
                    {
                        CompComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new WareHouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WareHouseName = elem.Element("WareHouseName").Value,
                        ResponsiblePersonFCS = elem.Element("ResponsiblePersonFCS").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        WareHouseComponents = CompComp
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
                    new XElement("DetailName", detail.Detail)));
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
                    new XElement("ProductId", order.ProductId),
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
                     new XElement("EngineName", engine.Engine),
                     new XElement("Price", engine.Price),
                     detElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(EngineFileName);
            }
        }
        private void SaveWareHouses()
        {
            if (WareHouses != null)
            {
                var xElement = new XElement("WareHouses");
                foreach (var wareHouse in WareHouses)
                {
                    var wareHouseElement = new XElement("WareHouseComponents");
                    foreach (var component in wareHouse.WareHouseComponents)
                    {
                        wareHouseElement.Add(new XElement("WareHouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("WareHouse",
                     new XAttribute("Id", wareHouse.Id),
                     new XElement("WareHouseName", wareHouse.WareHouseName),
                     new XElement("ResponsiblePersonFCS", wareHouse.ResponsiblePersonFCS),
                     new XElement("DateCreate", wareHouse.DateCreate),
                     wareHouseElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(WareHouseFileName);
            }
        }
    }
}
