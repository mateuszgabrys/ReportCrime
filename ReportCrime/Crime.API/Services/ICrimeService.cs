using Crime.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crime.API.Services
{
    public interface ICrimeService
    {
        Task<IEnumerable<CrimeEventDto>> GetAll();
        Task<CrimeEventDto> GetById(string id);
        Task<CrimeEventDto> Add(CreateCrimeEventDto createCrimeEventDto);
        Task Edit(CrimeEventDto crimeEventDto);
        Task Delete(string id);
    }
}
