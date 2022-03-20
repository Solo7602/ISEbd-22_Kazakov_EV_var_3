using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using AbstractFactoryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDatabaseImplement.Implements
{
    public class DetailStorage : IDetailStorage
    {
        public List<DetailViewModel> GetFullList()
        {
            using var context = new AbstractFactoryDatabase();
            return context.Detail
            .Select(CreateModel)
            .ToList();
        }
        public List<DetailViewModel> GetFilteredList(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractFactoryDatabase();
            return context.Detail
            .Where(rec => rec.DetailName.Contains(model.Detail))
            .Select(CreateModel)
            .ToList();
        }
        public DetailViewModel GetElement(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractFactoryDatabase();
            var detail = context.Detail
            .FirstOrDefault(rec => rec.DetailName == model.Detail || rec.Id
           == model.Id);
            return detail != null ? CreateModel(detail) : null;
        }
        public void Insert(DetailBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            context.Detail.Add(CreateModel(model, new Detail()));
            context.SaveChanges();
        }
        public void Update(DetailBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            var element = context.Detail.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(DetailBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            Detail element = context.Detail.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Detail.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Detail CreateModel(DetailBindingModel model, Detail
       component)
        {
            component.DetailName = model.Detail;
            return component;
        }
        private static DetailViewModel CreateModel(Detail detail)
        {
            return new DetailViewModel
            {
                Id = detail.Id,
                Detail = detail.DetailName
            };
        }
    }
}
