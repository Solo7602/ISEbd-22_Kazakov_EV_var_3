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
    public class DetailStorage : IDetailStorage
    {
        private readonly DataListSingleton source;
        public DetailStorage()
        {
            source = DataListSingleton.GetInstance();
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
            .Where(rec => rec.Detail.Contains(model.Detail))
            .Select(CreateModel)
            .ToList();
        }
        public DetailViewModel GetElement(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Detail = source.Details
            .FirstOrDefault(rec => rec.Detail == model.Detail ||
            rec.Id == model.Id);
            return Detail != null ? CreateModel(Detail) : null;
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
            Details tempDetail = null;
            foreach (var detail in source.Details)
            {
                if (detail.Id == model.Id)
                {
                    tempDetail = detail;
                }
            }
            if (tempDetail == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempDetail);
        }
        public void Delete(DetailBindingModel model)
        {
            for (int i = 0; i < source.Details.Count; ++i)
            {
                if (source.Details[i].Id == model.Id.Value)
                {
                    source.Details.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Details CreateModel(DetailBindingModel model, Details
       detail)
        {
            detail.Detail = model.Detail;
            return detail;
        }
        private static DetailViewModel CreateModel(Details detail)
        {
            return new DetailViewModel
            {
                Id = detail.Id,
                Detail = detail.Detail
            };
        }
    }
}
