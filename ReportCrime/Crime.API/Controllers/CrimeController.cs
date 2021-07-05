using Crime.API.Data;
using Crime.API.Models;
using Crime.API.Models.Dto;
using Crime.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crime.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrimeController : Controller
    {
        private readonly ILogger<CrimeController> _logger;
        private readonly ICrimeService _service;
        public CrimeController(ILogger<CrimeController> logger, ICrimeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrimeEventDto>>> GetAllCrimes()
        {
            var crimes = await _service.GetAll();
            return Ok(crimes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CrimeEventDto>>> GetCrime([FromRoute] string id)
        {
            var crime = await _service.GetById(id);
            return Ok(crime);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCrimeEventDto dto)
        {
            var newCrime = await _service.Add(dto);
            return Ok(newCrime);
        }
    }
}
