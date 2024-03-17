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

        public async Task<Image> CreateAsync(Image imageModel)
        {
            await _context.Image.AddAsync(imageModel);
            await _context.SaveChangesAsync();
            return imageModel;
        }

        public async Task<Image?> DeleteAsync(int id)
        {
            var imageModel = await _context.Image.FirstOrDefaultAsync(x => x.Id == id);

            if (imageModel == null)
            {
                return null;
            }

            _context.Image.Remove(imageModel);
            await _context.SaveChangesAsync();
            return imageModel;
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Image.ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Image.FindAsync(id);
        }

        public async Task<Image?> UpdateAsync(int id, Image imageModel)
        {
            var existingImage = await _context.Image.FindAsync(id);

            if (existingImage == null)
            {
                return null;
            }

            existingImage.ItemImage = imageModel.ItemImage;

            await _context.SaveChangesAsync();

            return existingImage;
        }
    }
}