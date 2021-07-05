using Crime.API.Data;
using Crime.API.Models;
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
        private readonly CrimeContext _context;
        public CrimeController(ILogger<CrimeController> logger, CrimeContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CrimeEvent>> Get()
        {
            return await _context.Crimes.Find(p => true).ToListAsync();
        }
    }
}
