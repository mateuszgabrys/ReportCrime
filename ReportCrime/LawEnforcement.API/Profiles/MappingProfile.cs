using AutoMapper;
using LawEnforcement.API.Models;
using LawEnforcement.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LawEnf, LawEnfDto>();
            CreateMap<LawEnfDto, LawEnf>();
            CreateMap<CrimeEvent, CrimeEventDto>();
            CreateMap<CrimeEventDto, CrimeEvent>();
        }
    }
}
