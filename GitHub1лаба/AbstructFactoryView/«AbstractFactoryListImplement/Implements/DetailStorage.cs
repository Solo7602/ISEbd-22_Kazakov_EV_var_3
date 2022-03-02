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
            var result = new List<DetailViewModel>();
            foreach (var detail in source.Details)
            {
                result.Add(CreateModel(detail));
            }
            return result;
        }
        public List<DetailViewModel> GetFilteredList(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<DetailViewModel>();
            foreach (var detail in source.Details)
            {
                if (detail.Detail.Contains(model.Detail))
                {
                    result.Add(CreateModel(detail));
                }
            }
            return result;
        }
        public DetailViewModel GetElement(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var detail in source.Details)
            {
                if (detail.Id == model.Id || detail.Detail ==
               model.Detail)
                {
                    return CreateModel(detail);
                }
            }
            return null;
        }
        public void Insert(DetailBindingModel model)
        {
            var tempDetail = new Details { Id = 1 };
            foreach (var detail in source.Details)
            {
                if (detail.Id >= tempDetail.Id)
                {
                    tempDetail.Id = detail.Id + 1;
                }
            }
            source.Details.Add(CreateModel(model, tempDetail));
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
