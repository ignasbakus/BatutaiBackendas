using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllAsync();
        Task<Image?> GetByIdAsync(int id);
    }
}