using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trampoline;
using api.Models;

namespace api.Interfaces
{
    public interface ITrampolineRepository
    {
        Task<List<Trampoline>> GetAllAsync();
        Task<Trampoline?> GetByIdAsync(int id);
        Task<Trampoline> CreateAsync(Trampoline trampolineModel);
        Task<Trampoline?> UpdateAsync(int id, UpdateTrampolineRequestDto trampolineDto);
        Task<Trampoline?> DeleteAsync(int id);
        Task<bool> TrampolineExist(int id);
    }
}