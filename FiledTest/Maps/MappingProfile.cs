using AutoMapper;
using FiledTest.Dtos;
using FiledTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledTest.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentDto, Payment>();
        }
    }
}
