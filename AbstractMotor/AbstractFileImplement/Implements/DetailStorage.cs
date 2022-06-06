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
    public class DetailStorage : IDetailStorage
    {
        private readonly FileDataListSingleton source;
        public DetailStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<DetailViewModel> GetFullList()
        {
            return source.Details
            .Select(CreateModel)
           .ToList();
        }
        public List<DetailViewModel> GetFilteredList(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Details
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
            var detail = source.Details
            .FirstOrDefault(rec => rec.DetailName == model.Detail ||
           rec.Id == model.Id);
            return detail != null ? CreateModel(detail) : null;
        }
        public void Insert(DetailBindingModel model)
        {
            int maxId = source.Details.Count > 0 ? source.Details.Max(rec =>
           rec.Id) : 0;
            var element = new Details { Id = maxId + 1 };
            source.Details.Add(CreateModel(model, element));
        }
        public void Update(DetailBindingModel model)
        {
            var element = source.Details.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(DetailBindingModel model)
        {
            Details element = source.Details.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Details.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Details CreateModel(DetailBindingModel model, Details
       component)
        {
            component.DetailName = model.Detail;
            return component;
        }
        private DetailViewModel CreateModel(Details details)
        {
            return new DetailViewModel
            {
                Id = details.Id,
                Detail = details.DetailName
            };
        }
    }
}
