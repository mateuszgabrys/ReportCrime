using AutoMapper;
using Crime.API.Models;
using Crime.API.Models.Dto;
using Crime.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crime.API.Services
{
    public class CrimeService : ICrimeService
    {
        private readonly ICrimeRepository _repository;
        private readonly IMapper _mapper;

        public CrimeService(ICrimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CrimeEventDto> Add(CreateCrimeEventDto createCrimeEventDto)
        {
            var mappedEntry = _mapper.Map<CrimeEvent>(createCrimeEventDto);
            var crime = await _repository.Add(mappedEntry);
            return _mapper.Map<CrimeEventDto>(crime);
        }

        public async Task Delete(string id)
        {
            await _repository.Delete(id);
        }

        public async Task Edit(CrimeEventDto crimeEventDto)
        {
            var crimeInDB = await _repository.GetSingle(x => x.CrimeId == crimeEventDto.CrimeId);
            _mapper.Map(crimeEventDto, crimeInDB);
            await _repository.Edit(crimeInDB);
        }

        public async Task<IEnumerable<CrimeEventDto>> GetAll()
        {
            var crimesInDb = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CrimeEventDto>>(crimesInDb);
        }

        public async Task<CrimeEventDto> GetById(string id)
        {
            var ecrimeInDb = await _repository.GetSingle(x => x.CrimeId == id);
            return _mapper.Map<CrimeEventDto>(ecrimeInDb);
        }
    }
}
