using AbstractFactoryFileImplement.Models;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryFileImplement.Implements
{
    public class EngineStorage : IEngineStorage
    {
        private readonly FileDataListSingleton source;
        public EngineStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<EngineViewModel> GetFullList()
        {
            return source.Engines
            .Select(CreateModel)
            .ToList();
        }
        public List<EngineViewModel> GetFilteredList(EngineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Engines
            .Where(rec => rec.EngineName.Contains(model.Engine))
            .Select(CreateModel)
            .ToList();
        }
        public EngineViewModel GetElement(EngineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var engine = source.Engines
            .FirstOrDefault(rec => rec.EngineName == model.Engine || rec.Id
           == model.Id);
            return engine != null ? CreateModel(engine) : null;
        }
        public void Insert(EngineBindingModel model)
        {
            int maxId = source.Engines.Count > 0 ? source.Engines.Max(rec => rec.Id)
: 0;
            var element = new Engines
            {
                Id = maxId + 1,
                EngineDetails = new
           Dictionary<int, int>()
            };
            source.Engines.Add(CreateModel(model, element));
        }
        public void Update(EngineBindingModel model)
        {
            var element = source.Engines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(EngineBindingModel model)
        {
            Engines element = source.Engines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Engines.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Engines CreateModel(EngineBindingModel model, Engines product)
        {
            product.EngineName = model.Engine;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.EngineDetails.Keys.ToList())
            {
                if (!model.EngineDetails.ContainsKey(key))
                {
                    product.EngineDetails.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.EngineDetails)
            {
                if (product.EngineDetails.ContainsKey(component.Key))
                {
                    product.EngineDetails[component.Key] =
                   model.EngineDetails[component.Key].Item2;
                }
                else
                {
                    product.EngineDetails.Add(component.Key,
                   model.EngineDetails[component.Key].Item2);
                }
            }
            return product;
        }
        private EngineViewModel CreateModel(Engines engine)
        {
            return new EngineViewModel
            {
                Id = engine.Id,
                Engine = engine.EngineName,
                Price = engine.Price,
                EngineDetails = engine.EngineDetails
 .ToDictionary(recPC => recPC.Key, recPC =>
 (source.Engines.FirstOrDefault(recC => recC.Id ==
recPC.Key)?.EngineName, recPC.Value))
            };
        }
    }
}
