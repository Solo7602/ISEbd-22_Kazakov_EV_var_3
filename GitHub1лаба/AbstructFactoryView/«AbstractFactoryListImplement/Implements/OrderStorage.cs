using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using _AbstractFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.Enums;

namespace _AbstractFactoryListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if ((!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate == model.DateCreate) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (/*model.ClientId.HasValue &&*/ order.ClientId == model.ClientId) ||
                    (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status) ||
                    (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && model.Status == order.Status))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var component in source.Orders)
            {
                if (component.Id == model.Id || component.ProductId == model.EngineId)
                {
                    return CreateModel(component);
                }
            }
            return null;
        }
        public void Insert(OrderBindingModel model)
        {
            Orders tempOrder = new Orders { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }
        public void Update(OrderBindingModel model)
        {
            Orders tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Orders CreateModel(OrderBindingModel model, Orders order)
        {
            order.ClientId = (int)model.ClientId;
            order.ProductId = model.EngineId;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateImplement = model.DateImplement;
            order.DateCreate = model.DateCreate;
            return order;
        }
        private OrderViewModel CreateModel(Orders order)
        {
            string engineName = "";
            foreach (var engine in source.Engines)
            {
                if (engine.Id == order.ProductId)
                {
                    engineName = engine.Engine;
                    break;
                }
            }
            string clientFIO = null;
            foreach (Clients client in source.Clients)
            {
                if (order.ClientId == client.Id)
                {
                    clientFIO = client.ClientFIO;
                    break;
                }
            }
            string implementerFIO = null;
            if (order.ImplementerId != null)
            {
                foreach (var implementer in source.Implementers)
                {
                    if (implementer.Id == order.ImplementerId)
                    {
                        implementerFIO = implementer.ImplementerFIO;
                        break;
                    }
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                ClientId = order.ClientId,
                ClientFIO = clientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = implementerFIO,
                Sum = order.Sum,
                Count = order.Count,
                Status = order.Status,
                Engine = engineName,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
