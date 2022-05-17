﻿using _AbstractFactoryListImplement.Models;
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
            var result = new List<ClientViewModel>();

            foreach (var client in source.Clients)
            {
                result.Add(CreateModel(client));
            }

            return result;
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<ClientViewModel>();

            foreach (var client in source.Clients)
            {
                if (client.Email.Contains(model.Email))
                {
                    result.Add(CreateModel(client));
                }
            }

            return result;
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id)
                {
                    return CreateModel(client);
                }
            }

            return null;
        }

        public void Insert(ClientBindingModel model)
        {
            var tmpClient = new Clients { Id = 1 };

            foreach (var client in source.Clients)
            {
                if (client.Id >= tmpClient.Id)
                {
                    tmpClient.Id = client.Id + 1;
                }
            }

            source.Clients.Add(CreateModel(model, tmpClient));
        }

        public void Update(ClientBindingModel model)
        {
            Clients tmpClient = null;
            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id)
                {
                    tmpClient = client;
                }
            }

            if (tmpClient == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tmpClient);
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

        private Clients CreateModel(ClientBindingModel model, Clients client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }

        private ClientViewModel CreateModel(Clients client)
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
