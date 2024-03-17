using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Image;
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
        private readonly ITrampolineRepository _trampolineRepo;
        public ImageController(IImageRepository imageRepo, ITrampolineRepository trampolineRepo)
        {
            _imageRepo = imageRepo;
            _trampolineRepo = trampolineRepo;
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

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image.toImageDto());
        }

        [HttpPost("{trampolineId}")]
        public async Task<IActionResult> Create([FromRoute] int trampolineId, CreateImageDto imageDto)
        {
            if (!await _trampolineRepo.TrampolineExist(trampolineId))
            {
                return BadRequest("Trampoline does not exist");
            }

            var imageModel = imageDto.toImageFromCreate(trampolineId);
            await _imageRepo.CreateAsync(imageModel);
            return CreatedAtAction(nameof(GetById), new { id = imageModel.Id }, imageModel.toImageDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateImageRequestDto updateDto)
        {
            var image = await _imageRepo.UpdateAsync(id, updateDto.toImageFromUpdate());

            if (image == null)
            {
                return NotFound("Image not Found");
            }

            return Ok(image.toImageDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var imageModel = await _imageRepo.DeleteAsync(id);

            if (imageModel == null)
            {
                return NotFound("Image does not exist");
            }

            return Ok(imageModel);
        }
    }
}