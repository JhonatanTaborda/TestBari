using Application.DataTransferObjects;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public class ProfileMapService 
    {
        public ProfileMapService()
        {

        }   

        public IMapper CreateMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessageDto>();
            });


            return config.CreateMapper();

        }
    }
}
