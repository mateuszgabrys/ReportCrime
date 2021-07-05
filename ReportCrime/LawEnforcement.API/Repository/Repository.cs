using AutoMapper;
using LawEnforcement.API.DbContexts;
using LawEnforcement.API.Models;
using LawEnforcement.API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LawEnforcement.API.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LawEnfDto> Add(LawEnfDto lawEnf)
        {
            LawEnf lawEnforced = _mapper.Map<LawEnfDto, LawEnf>(lawEnf);
            _context.LawEnfs.Add(lawEnforced);
            await _context.SaveChangesAsync();
            return _mapper.Map<LawEnf, LawEnfDto>(lawEnforced);
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                LawEnf lawEnforced = await _context.LawEnfs.FirstOrDefaultAsync(x => x.LawEnfId == id);
                _context.LawEnfs.Remove(lawEnforced);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<LawEnfDto> Edit(LawEnfDto lawEnf)
        {
            LawEnf lawEnforced = _mapper.Map<LawEnfDto, LawEnf>(lawEnf);

            _context.LawEnfs.Update(lawEnforced);
            await _context.SaveChangesAsync();
            return _mapper.Map<LawEnf, LawEnfDto>(lawEnforced);
        }

        public async Task<IList<LawEnfDto>> GetAll()
        {
            List<LawEnf> lawEnfList = await _context.LawEnfs.ToListAsync();
            return _mapper.Map<List<LawEnfDto>>(lawEnfList);
        }

        public async Task<LawEnfDto> GetSingle(string id)
        {
            LawEnf lawEnforced = await _context.LawEnfs.Where(x => x.LawEnfId == id).FirstOrDefaultAsync();
            return _mapper.Map<LawEnfDto>(lawEnforced);
        }
    }
}
