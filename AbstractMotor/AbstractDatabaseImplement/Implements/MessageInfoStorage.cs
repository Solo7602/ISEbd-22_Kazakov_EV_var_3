using AbstractFactoryDatabaseImplement.Models;
using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.StoragesContracts;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new AbstractFactoryDatabase();
            return context.MessageInfos
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                SenderName = rec.SenderName,
                DateDelivery = rec.DateDelivery,
                Subject = rec.Subject,
                Body = rec.Body
            })
        .ToList();
        }
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractFactoryDatabase())
            {
                var message = context.MessageInfos
                .FirstOrDefault(rec => rec.MessageId == model.MessageId);
                return message != null ?
                new MessageInfoViewModel
                {
                    MessageId = message.MessageId,
                    Subject = message.Subject,
                    Body = message.Body,
                    DateDelivery = message.DateDelivery,
                    SenderName = message.SenderName
                } :
                null;
            }
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
{
    if (model == null)
    {
        return null;
    }
    using var context = new AbstractFactoryDatabase();
    return context.MessageInfos
    .Where(rec => (model.ClientId.HasValue && rec.ClientId ==
    model.ClientId) ||
    (!model.ClientId.HasValue &&
    rec.DateDelivery.Date == model.DateDelivery.Date))
    .Select(rec => new MessageInfoViewModel
    {
        MessageId = rec.MessageId,
        SenderName = rec.SenderName,
        DateDelivery = rec.DateDelivery,
        Subject = rec.Subject,
        Body = rec.Body
    })
    .ToList();
    }
        public void Insert(MessageInfoBindingModel model)
        {
            using var context = new AbstractFactoryDatabase();
            MessageInfo element = context.MessageInfos.FirstOrDefault(rec =>
            rec.MessageId == model.MessageId);
        if (element != null)
        {
            throw new Exception("Уже есть письмо с таким идентификатором");
        }
            context.MessageInfos.Add(new MessageInfo
            {
                 MessageId = model.MessageId,
                   ClientId = model.ClientId,
        SenderName = model.FromMailAddress,
        DateDelivery = model.DateDelivery,
        Subject = model.Subject,
        Body = model.Body
    });
    context.SaveChanges();
        }   
    }
}
