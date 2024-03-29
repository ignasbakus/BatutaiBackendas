using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Trampoline;
using api.Helpers;
using api.Interfaces;
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
        private readonly ITrampolineRepository _trampolineRepo;

        // Constructor
        public TrampolineController(ApllicationDBContext context, ITrampolineRepository trampolineRepo)
        {
            _trampolineRepo = trampolineRepo;
            _context = context;
        }

        // Retrieves all trampolines from the db
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trampolines = await _trampolineRepo.GetAllAsync(query);
            // Select is basically map, and it maps through the data so you can use it
            var trampolineDto = trampolines.Select(s => s.ToTrampolineDto());

            return Ok(trampolines);
        }

        // retrieves only a specific trampoline
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find() finds the specific ID trampoline
            var trampoline = await _trampolineRepo.GetByIdAsync(id);

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trampolineModel = trampolineDto.ToTrampolineFromCreateDTO();
            await _trampolineRepo.CreateAsync(trampolineModel);
            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTrampolineRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trampolineModel = await _trampolineRepo.UpdateAsync(id, updateDto);

            if (trampolineModel == null)
            {
                return NotFound();
            }

            return Ok(trampolineModel.ToTrampolineDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trampolineModel = await _trampolineRepo.DeleteAsync(id);

            if (trampolineModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}