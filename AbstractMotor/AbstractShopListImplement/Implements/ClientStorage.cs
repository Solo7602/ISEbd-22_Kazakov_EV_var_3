using _AbstractFactoryListImplement.Models;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _AbstractFactoryListImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataListSingleton source;
        public ClientStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ClientViewModel> GetFullList()
        {
            return source.Clients
            .Select(CreateModel)
            .ToList();

        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Clients
            .Where(rec => rec.ClientFIO.Contains(model.ClientFIO))
            .Select(CreateModel)
            .ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Client = source.Clients
            .FirstOrDefault(rec => rec.ClientFIO == model.ClientFIO ||
            rec.Id == model.Id);
            return Client != null ? CreateModel(Client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec =>
rec.Id) : 0;
            var element = new Clients { Id = maxId + 1 };
            source.Clients.Add(CreateModel(model, element));
        }
        public void Update(ClientBindingModel model)
        {
            Clients tempClient = null;
            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id)
                {
                    tempClient = client;
                }
            }
            if (tempClient == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempClient);
        }
        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Clients CreateModel(ClientBindingModel model, Clients
       client)
        {
            client.ClientFIO = model.ClientFIO;
            return client;
        }
        private static ClientViewModel CreateModel(Clients client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Email = client.Email,
                Password = client.Password
            };
        }
    }
}
