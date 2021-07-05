using LawEnforcement.API.Models.Dto;
using LawEnforcement.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LawEnforcementController : Controller
    {
        private IRepository _repository;
        protected ResponseDto _response;

        public LawEnforcementController(IRepository repository)
        {
            _repository = repository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<LawEnfDto> lawEnfDtos = await _repository.GetAll();
                _response.Result = lawEnfDtos;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(string id)
        {
            try
            {
                LawEnfDto lawEnfDto = await _repository.GetSingle(id);
                _response.Result = lawEnfDto;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] LawEnfDto lawEnfDto)
        {
            try
            {
                LawEnfDto model = await _repository.Add(lawEnfDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] LawEnfDto lawEnfDto)
        {
            try
            {
                LawEnfDto model = await _repository.Edit(lawEnfDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(string id)
        {
            try
            {
                bool isSucces = await _repository.Delete(id);
                _response.Result = isSucces;
            }
            catch (Exception ex)
            {

                _response.IsSucces = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
