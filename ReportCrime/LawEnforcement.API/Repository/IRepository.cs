using LawEnforcement.API.Models;
using LawEnforcement.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LawEnforcement.API.Repository
{
    public interface IRepository
    {
        Task<IList<LawEnfDto>> GetAll();
        Task<LawEnfDto> GetSingle(string id);
        Task<LawEnfDto> Add(LawEnfDto lawEnf);
        Task<LawEnfDto> Edit(LawEnfDto lawEnf);
        Task<bool> Delete(string id);
    }
}
