using AutoMapper;
using Crime.API.Models;
using Crime.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crime.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCrimeEventDto, CrimeEvent>();
            CreateMap<CrimeEvent, CreateCrimeEventDto>();
            CreateMap<CrimeEvent, CrimeEventDto>();
            CreateMap<CrimeEventDto, CrimeEvent>();
        }
    }
}
