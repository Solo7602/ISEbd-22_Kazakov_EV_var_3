﻿using AbstructFactoryContracts.BindingModels;
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
    public class WareHouseStorage : IWareHouseStorage
    {
            private readonly FileDataListSingleton source;
            public WareHouseStorage()
            {
                source = FileDataListSingleton.GetInstance();
            }
            public List<WareHouseViewModel> GetFullList()
            {
                return source.WareHouses
                .Select(CreateModel)
                .ToList();
            }
            public List<WareHouseViewModel> GetFilteredList(WareHouseBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                return source.WareHouses
                .Where(rec => rec.WareHouseName.Contains(model.WareHouseName))
                .Select(CreateModel)
                .ToList();
            }
            public WareHouseViewModel GetElement(WareHouseBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                var wareHouse = source.WareHouses
                .FirstOrDefault(rec => rec.WareHouseName == model.WareHouseName || rec.Id
               == model.Id);
                return wareHouse != null ? CreateModel(wareHouse) : null;
            }
            public void Insert(WareHouseBindingModel model)
            {
                int maxId = source.WareHouses.Count > 0 ? source.WareHouses.Max(rec => rec.Id) : 0;
                var element = new WareHouse
                {
                    Id = maxId + 1,
                    WareHouseComponents = new Dictionary<int, int>(),
                    DateCreate = DateTime.Now
                };
                source.WareHouses.Add(CreateModel(model, element));
            }
            public void Update(WareHouseBindingModel model)
            {
                var element = source.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
            }
            public void Delete(WareHouseBindingModel model)
            {
                WareHouse element = source.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    source.WareHouses.Remove(element);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            private static WareHouse CreateModel(WareHouseBindingModel model, WareHouse wareHouse)
            {
                wareHouse.WareHouseName = model.WareHouseName;
                wareHouse.ResponsiblePersonFCS = model.ResponsiblePersonFCS;
                wareHouse.DateCreate = model.DateCreate;
                // удаляем убранные
                foreach (var key in wareHouse.WareHouseComponents.Keys.ToList())
                {
                    if (!model.WareHouseComponents.ContainsKey(key))
                    {
                        wareHouse.WareHouseComponents.Remove(key);
                    }
                }
                // обновляем существуюущие и добавляем новые
                foreach (var component in model.WareHouseComponents)
                {
                    if (wareHouse.WareHouseComponents.ContainsKey(component.Key))
                    {
                        wareHouse.WareHouseComponents[component.Key] =
                       model.WareHouseComponents[component.Key].Item2;
                    }
                    else
                    {
                        wareHouse.WareHouseComponents.Add(component.Key,
                       model.WareHouseComponents[component.Key].Item2);
                    }
                }
                return wareHouse;
            }
            private WareHouseViewModel CreateModel(WareHouse wareHouse)
            {
                return new WareHouseViewModel
                {
                    Id = wareHouse.Id,
                    WareHouseName = wareHouse.WareHouseName,
                    ResponsiblePersonFIO = wareHouse.ResponsiblePersonFCS,
                    DateCreate = wareHouse.DateCreate,
                    WareHouseComponents = wareHouse.WareHouseComponents
         .ToDictionary(recPC => recPC.Key, recPC =>
         (source.Details.FirstOrDefault(recC => recC.Id ==
        recPC.Key)?.Detail, recPC.Value))
                };
            }
            public bool TakeFromWareHouses(Dictionary<int, (string, int)> components, int reinforcedCount)
            {
                foreach (var component in components)
                {
                    int count = source.WareHouses.Where(comp => comp.WareHouseComponents.ContainsKey(component.Key)).Sum(comp => comp.WareHouseComponents[component.Key]);

                    if (count < component.Value.Item2 * reinforcedCount)
                    {
                        return false;
                    }
                }

                foreach (var component in components)
                {
                    int count = component.Value.Item2 * reinforcedCount;
                    IEnumerable<WareHouse> wareHouses = source.WareHouses.Where(comp => comp.WareHouseComponents.ContainsKey(component.Key));

                    foreach (WareHouse wareHouse in wareHouses)
                    {
                        if (wareHouse.WareHouseComponents[component.Key] <= count)
                        {
                            count -= wareHouse.WareHouseComponents[component.Key];
                            wareHouse.WareHouseComponents.Remove(component.Key);
                        }
                        else
                        {
                            wareHouse.WareHouseComponents[component.Key] -= count;
                            count = 0;
                        }

                        if (count == 0)
                        {
                            break;
                        }
                    }
                }

                return true;
            }
        }
}
