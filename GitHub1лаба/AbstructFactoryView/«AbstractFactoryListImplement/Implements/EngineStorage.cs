using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using _AbstractFactoryListImplement.Models;

namespace _AbstractFactoryListImplement.Implements
{
    public class EngineStorage : IEngineStorage
    {
        private readonly DataListSingleton source;
        public EngineStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<EngineViewModel> GetFullList()
        {
            var result = new List<EngineViewModel>();
            foreach (var component in source.Engines)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<EngineViewModel> GetFilteredList(EngineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<EngineViewModel>();
            foreach (var engine in source.Engines)
            {
                if (engine.Engine.Contains(model.Engine))
                {
                    result.Add(CreateModel(engine));
                }
            }
            return result;
        }
        public EngineViewModel GetElement(EngineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var engine in source.Engines)
            {
                if (engine.Id == model.Id || engine.Engine ==
                model.Engine)
                {
                    return CreateModel(engine);
                }
            }
            return null;
        }
        public void Insert(EngineBindingModel model)
        {
            var tempEngines = new Engines
            {
                Id = 1,
                EngineDetails = new
            Dictionary<int, int>()
            };
            foreach (var engine in source.Engines)
            {
                if (engine.Id >= tempEngines.Id)
                {
                    tempEngines.Id = engine.Id + 1;
                }
            }
            source.Engines.Add(CreateModel(model, tempEngines));
        }
        public void Update(EngineBindingModel model)
        {
            Engines tempEngines = null;
            foreach (var engines in source.Engines)
            {
                if (engines.Id == model.Id)
                {
                    tempEngines = engines;
                }
            }
            if (tempEngines == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempEngines);
        }
        public void Delete(EngineBindingModel model)
        {
            for (int i = 0; i < source.Engines.Count; ++i)
            {
                if (source.Engines[i].Id == model.Id)
                {
                    source.Engines.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Engines CreateModel(EngineBindingModel model,Engines engine)
        {
            engine.Engine = model.Engine;
            engine.Price = model.Price;
            foreach (var key in engine.EngineDetails.Keys.ToList())
            {
                if (!model.EngineDetails.ContainsKey(key))
                {
                    engine.EngineDetails.Remove(key);
                }
            }
            foreach (var component in model.EngineDetails)
            {
                if (engine.EngineDetails.ContainsKey(component.Key))
                {
                    engine.EngineDetails[component.Key] =
                    model.EngineDetails[component.Key].Item2;
                }
                else
                {
                    engine.EngineDetails.Add(component.Key,
                    model.EngineDetails[component.Key].Item2);
                }
            }
            return engine;
        }
        private EngineViewModel CreateModel(Engines engine)
        {
            var engineDetail = new Dictionary<int, (string, int)>();
            foreach (var eng in engine.EngineDetails)
            {
                string engines = string.Empty;
                foreach (var details in source.Details)
                {
                    if (eng.Key == engine.Id)
                    {
                        engines = engine.Engine;
                        break;
                    }
                }
                engineDetail.Add(eng.Key, (engines, eng.Value));
            }
            return new EngineViewModel
            {
                Id = engine.Id,
                Engine = engine.Engine,
                Price = engine.Price,
                EngineDetails = engineDetail
            };
        }

    }
}
