using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepo;
        public ImageController(IImageRepository imageRepo)
        {
            _imageRepo = imageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var images = await _imageRepo.GetAllAsync();
            
            var imageDto = images.Select(s => s.toImageDto());

            return Ok(imageDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var image = await _imageRepo.GetByIdAsync(id);

            if(image == null)
            {
                return NotFound();
            }

            return Ok(image.toImageDto());
        }
    }
}