using AutoMapper;
using CrmallTeste.AppService.DTO;
using CrmallTeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmallTeste.AppService.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {

            CreateMap<Personal, PersonalDTO>().ReverseMap();

        }
    }
}
