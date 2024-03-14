using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApllicationDBContext _context;
        public ImageRepository(ApllicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Image.ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Image.FindAsync(id);
        }
    }
}