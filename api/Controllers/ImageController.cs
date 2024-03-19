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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var images = await _imageRepo.GetAllAsync();

            var imageDto = images.Select(s => s.toImageDto());

            return Ok(imageDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await _imageRepo.GetByIdAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image.toImageDto());
        }

        [HttpPost("{trampolineId:int}")]
        public async Task<IActionResult> Create([FromRoute] int trampolineId, CreateImageDto imageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _trampolineRepo.TrampolineExist(trampolineId))
            {
                return BadRequest("Trampoline does not exist");
            }

            var imageModel = imageDto.toImageFromCreate(trampolineId);
            await _imageRepo.CreateAsync(imageModel);
            return CreatedAtAction(nameof(GetById), new { id = imageModel.Id }, imageModel.toImageDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateImageRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var image = await _imageRepo.UpdateAsync(id, updateDto.toImageFromUpdate());

            if (image == null)
            {
                return NotFound("Image not Found");
            }

            return Ok(image.toImageDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var imageModel = await _imageRepo.DeleteAsync(id);

            if (imageModel == null)
            {
                return NotFound("Image does not exist");
            }

            return Ok(imageModel);
        }
    }
}