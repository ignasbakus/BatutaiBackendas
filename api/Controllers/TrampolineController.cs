using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            // ToList() makes the objects as a list so it can load them into the memory. List offers more functionality
            var trampolines = _context.Trampolines.ToList();

            return Ok(trampolines);
        }

        // retrieves only a specific trampoline
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // Find() finds the specific ID trampoline
            var trampoline = _context.Trampolines.Find(id);

            // If there is no trampoline with such id, returns NotFound()
            if(trampoline == null)
            {
                return NotFound();
            }

            return Ok(trampoline);
        }
    }
}