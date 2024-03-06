using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Trampoline;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/trampoline")]
    [ApiController]
    public class TrampolineController : ControllerBase
    {
        private readonly ApllicationDBContext _context;
        public TrampolineController(ApllicationDBContext context)
        {
            _context = context;
        }

        // Retrieves all trampolines from the db
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // ToList() makes the objects as a list so it can load them into the memory. List offers more functionality
            var trampolines = await _context.Trampolines.ToListAsync();
            // Select is basically map, and it maps through the data so you can use it
            var trampolineDto = trampolines.Select(s => s.ToTrampolineDto());

            return Ok(trampolines);
        }

        // retrieves only a specific trampoline
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // Find() finds the specific ID trampoline
            var trampoline = await _context.Trampolines.FindAsync(id);

            // If there is no trampoline with such id, returns NotFound()
            if (trampoline == null)
            {
                return NotFound();
            }

            return Ok(trampoline.ToTrampolineDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrampolineRequestDto trampolineDto)
        {
            var trampolineModel = trampolineDto.ToTrampolineFromCreateDTO();
            await _context.Trampolines.AddAsync(trampolineModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = trampolineModel.Id }, trampolineModel.ToTrampolineDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTrampolineRequestDto updateDto)
        {
            var trampolineModel = await _context.Trampolines.FirstOrDefaultAsync(x => x.Id == id);

            if (trampolineModel == null)
            {
                return NotFound();
            }

            trampolineModel.Name = updateDto.Name;
            trampolineModel.Image = updateDto.Image;
            trampolineModel.Price = updateDto.Price;
            trampolineModel.Width = updateDto.Width;
            trampolineModel.Height = updateDto.Height;
            trampolineModel.Length = updateDto.Length;
            trampolineModel.Description = updateDto.Description;

            await _context.SaveChangesAsync();

            return Ok(trampolineModel.ToTrampolineDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var trampolineModel = await _context.Trampolines.FirstOrDefaultAsync(x => x.Id == id);

            if (trampolineModel == null)
            {
                return NotFound();
            }

            _context.Trampolines.Remove(trampolineModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}