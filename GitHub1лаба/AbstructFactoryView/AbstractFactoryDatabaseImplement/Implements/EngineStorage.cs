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
    public class EngineStorage : IEngineStorage
    {
        public List<EngineViewModel> GetFullList()
        {
            using var context = new AbstractFactoryDatabase();
            return context.Engines
            .Include(rec => rec.EngineDetail)
            .ThenInclude(rec => rec.Detail)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<EngineViewModel> GetFilteredList(EngineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractFactoryDatabase();
            return context.Engines
            .Include(rec => rec.EngineDetail)
            .ThenInclude(rec => rec.Detail)
            .Where(rec => rec.EngineName.Contains(model.Engine))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public EngineViewModel GetElement(EngineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractFactoryDatabase();
            var product = context.Engines
            .Include(rec => rec.EngineDetail)
            .ThenInclude(rec => rec.Detail)
            .FirstOrDefault(rec => rec.EngineName == model.Engine ||
            rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }
        public void Insert(EngineBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Engines.Add(CreateModel(model, new Engine(),
                context));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(EngineBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Engines.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(EngineBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            Engine element = context.Engines.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Engines.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Engine CreateModel(EngineBindingModel model, Engine engine,
       AbstractFactoryDatabase context)
        {
            engine.EngineName = model.Engine;
            engine.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.EngineDetail.Where(rec =>
               rec.EngineId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.EngineDetail.RemoveRange(productComponents.Where(rec =>
               !model.EngineDetails.ContainsKey(rec.EngineId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                   model.EngineDetails[updateComponent.EngineId].Item2;
                    model.EngineDetails.Remove(updateComponent.DetailId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.EngineDetails)
            {
                context.EngineDetail.Add(new EngineDetail
                {
                    EngineId = engine.Id,
                    DetailId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return engine;
        }
        private static EngineViewModel CreateModel(Engine engine)
        {
            return new EngineViewModel
            {
                Id = engine.Id,
                Engine = engine.EngineName,
                Price = engine.Price,
                EngineDetails = engine.EngineDetail.ToDictionary(recPC => recPC.EngineId,
            recPC => (recPC.Detail?.DetailName, recPC.Count))
            };
        }
    }
}
