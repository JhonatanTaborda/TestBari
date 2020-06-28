using Application.DataTransferObjects;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AppServices
{
    public class MessageAppService : IMessageAppService
    {

        private readonly IMessageService _messageService;

        private readonly IMapper _mapper;

        public MessageAppService(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public MessageDto CreateMessage(string service)
        {
            return _mapper.Map<MessageDto>(_messageService.CreateMessage(service));
        }

        public byte[] EncodeMessage(MessageDto dto)
        {
            return Encoding.UTF8.GetBytes(SerializeMessage(dto));
        }

        public string DecodeMessage(ReadOnlyMemory<byte> message)
        {
            return Encoding.UTF8.GetString(message.ToArray());
        }

        public string ReturnMessage(MessageDto dto)
        {
            return SerializeMessage(dto);
        }

        private string SerializeMessage(MessageDto dto)
        {

            return
                 "Serviço: " +dto.Service + " >>> "+
                "ID: " + dto.Id +
                "; Message: " + dto.Desctiption +
                "; TimesPan: " + dto.TimeStamp;
        }

    }
}
