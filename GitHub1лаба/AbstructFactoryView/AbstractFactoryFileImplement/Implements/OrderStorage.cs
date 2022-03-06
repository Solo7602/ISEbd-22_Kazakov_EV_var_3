using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using _AbstractFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;
        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
            .Select(CreateModel)
            .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Orders
            .Where(rec => rec.ProductId.ToString().Contains(model.EngineId.ToString()))
            .Select(CreateModel)
            .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var order = source.Orders
            .FirstOrDefault(rec => rec.Id == model.Id || rec.ProductId == model.EngineId);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            Orders element = new Orders { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, element));
        }
        public void Update(OrderBindingModel model)
        {
            Orders element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(OrderBindingModel model)
        {
            Orders element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Orders CreateModel(OrderBindingModel model, Orders order)
        {
            order.ProductId = model.EngineId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Orders order)
        {
            string reinforcedName = null;
            foreach (Engines comp in source.Engines)
            {
                if (comp.Id == order.ProductId)
                {
                    reinforcedName = comp.Engine;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Engine = source.Engines.FirstOrDefault(x => x.Id == order.ProductId)?.Engine,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = order.Status,
                DateImplement = order.DateImplement
            };
        }
    }
}
