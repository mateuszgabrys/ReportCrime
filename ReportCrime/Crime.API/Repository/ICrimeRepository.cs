using Crime.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crime.API.Repository
{
    public interface ICrimeRepository
    {
        Task<IList<CrimeEvent>> GetAll();
        Task<CrimeEvent> GetSingle(Expression<Func<CrimeEvent, bool>> condition);
        Task<CrimeEvent> Add(CrimeEvent crimeEvent);
        Task Edit(CrimeEvent crimeEvent);
        Task Delete(string id);
    }
}
