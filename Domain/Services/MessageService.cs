using CrossCutting.Resources;
using CrossCutting.Utils;
using Domain.Interfaces;
using Domain.Models;
using System;


namespace Domain.Services
{
    public class MessageService : IMessageService 
    {

        public MessageService()
        {

        }

        public Message CreateMessage(string service)
        {
            return new Message()
            {
                Id = Guid.NewGuid(),
                Desctiption = MessageResource.Hello,
                TimeStamp = Util.GetTimestamp(DateTime.Now),
                Service = service
            };
        }
    }
}
