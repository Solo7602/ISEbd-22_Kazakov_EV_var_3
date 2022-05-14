using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using AbstractFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (AbstractFactoryDatabase context = new AbstractFactoryDatabase())
            {
                return context.Orders.Include(rec => rec.Engine)
                .Include(rec=>rec.Implementer)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ProductId = rec.EngineId,
                    Engine = rec.Engine.EngineName,
                    Count = rec.Count,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerFIO = rec.Implementer.ImplementerFIO,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                })
                .ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractFactoryDatabase context = new AbstractFactoryDatabase())
            {
                return context.Orders.Include(rec => rec.Engine).Include(rec => rec.Client)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date
                >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    ProductId = rec.EngineId,
                    Engine = rec.Engine.EngineName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                })
                .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractFactoryDatabase context = new AbstractFactoryDatabase())
            {
                Order order = context.Orders.Include(rec => rec.Engine)
                 .Include(rec => rec.Implementer)
                 .Include(rec => rec.Client)
                 .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    ProductId = order.EngineId,
                    ImplementerId = order.ImplementerId,
                    ClientId = order.ClientId,
                    ClientFIO = order.Client.ClientFIO,
                    Engine = order.Engine.EngineName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }
        public void Update(OrderBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (AbstractFactoryDatabase context = new AbstractFactoryDatabase())
            {
                Order order = new Order
                {
                    EngineId = model.EngineId,
                    Count = model.Count,
                    ClientId = (int)model.ClientId,
                    ImplementerId = model.ImplementerId,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (AbstractFactoryDatabase context = new AbstractFactoryDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (AbstractFactoryDatabase context = new AbstractFactoryDatabase())
            {
                Engine element = context.Engines.FirstOrDefault(rec => rec.Id == model.EngineId);
                Implementer impl = context.Implementers.FirstOrDefault(rec => rec.Id == model.ImplementerId);
                if (impl != null)
                {
                    if (impl.Orders == null)
                    {
                        impl.Orders = new List<Order>();
                        context.Implementers.Update(impl);
                        context.SaveChanges();
                    }
                    impl.Orders.Add(order);
                }
                if (element != null)
                {
                    if (element.Orders == null)
                    {
                        element.Orders = new List<Order>();
                    }


                    element.Orders.Add(order);

                    context.Engines.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}
