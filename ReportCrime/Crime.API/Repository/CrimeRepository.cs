using Crime.API.Data;
using Crime.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crime.API.Repository
{
    public class CrimeRepository : ICrimeRepository
    {
        private readonly CrimeContext _context;
        public CrimeRepository(CrimeContext context)
        {
            _context = context;
        }
        public async Task<CrimeEvent> Add(CrimeEvent crimeEvent)
        {
            await _context.Crimes.InsertOneAsync(crimeEvent);
            return crimeEvent;
        }

        public async Task Delete(string id)
        {
            await _context.Crimes.DeleteOneAsync(x => x.CrimeId == id);
        }

        public async Task Edit(CrimeEvent crimeEvent)
        {
            await _context.Crimes.ReplaceOneAsync(x => x.CrimeId == crimeEvent.CrimeId, crimeEvent);
        }

        public async Task<IList<CrimeEvent>> GetAll()
        {
            return await _context.Crimes.Find(e => true).ToListAsync();
        }

        public async Task<CrimeEvent> GetSingle(Expression<Func<CrimeEvent, bool>> condition)
        {
            return await _context.Crimes.Find(condition).FirstOrDefaultAsync();
        }
    }
}
