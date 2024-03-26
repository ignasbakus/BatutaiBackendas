using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Trampoline;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TrampolineRepository : ITrampolineRepository
    {
        private readonly ApllicationDBContext _context;
        public TrampolineRepository(ApllicationDBContext context)
        {
            _context = context;
        }

        public async Task<Trampoline> CreateAsync(Trampoline trampolineModel)
        {
            await _context.Trampolines.AddAsync(trampolineModel);
            await _context.SaveChangesAsync();
            return trampolineModel;
        }

        public async Task<Trampoline?> DeleteAsync(int id)
        {
            var trampolineModel = await _context.Trampolines.FirstOrDefaultAsync(x => x.Id == id);

            if (trampolineModel == null)
            {
                return null;
            }

            _context.Trampolines.Remove(trampolineModel);
            await _context.SaveChangesAsync();
            return trampolineModel;
        }

        public async Task<List<Trampoline>> GetAllAsync(QueryObject query)
        {
            var trampolines = _context.Trampolines.Include(c => c.Images).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                trampolines = trampolines.Where(s => s.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    trampolines = query.IsDescending ? trampolines.OrderByDescending(s => s.Price) : trampolines.OrderBy(s => s.Price);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await trampolines.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Trampoline?> GetByIdAsync(int id)
        {
            return await _context.Trampolines.Include(c => c.Images).FirstOrDefaultAsync(i => i.Id == id);

        }

        public Task<bool> TrampolineExist(int id)
        {
            return _context.Trampolines.AnyAsync(t => t.Id == id);
        }

        public async Task<Trampoline?> UpdateAsync(int id, UpdateTrampolineRequestDto trampolineDto)
        {
            var existingTrampoline = await _context.Trampolines.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTrampoline == null)
            {
                return null;
            }

            existingTrampoline.Name = trampolineDto.Name;
            existingTrampoline.Price = trampolineDto.Price;
            existingTrampoline.Width = trampolineDto.Width;
            existingTrampoline.Height = trampolineDto.Height;
            existingTrampoline.Length = trampolineDto.Length;
            existingTrampoline.Description = trampolineDto.Description;

            await _context.SaveChangesAsync();

            return existingTrampoline;
        }
    }
}