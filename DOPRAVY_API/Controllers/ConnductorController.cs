using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOPRAVY_API.Models;

namespace DOPRAVY_API.Controllers
{
    [Route("api/Conductor")]
    [ApiController]
    public class ConnductorController : ControllerBase
    {
        private readonly DopravyContext _context;

        public ConnductorController(DopravyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conductor>>> GetConductors()
        {
            return await _context.Conductors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conductor>> GetConductor(string id)
        {
            var conductor = await _context.Conductors.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            return conductor;
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPost]
        public async Task<ActionResult<Conductor>> PostConductor(Conductor conductor)
        {
            _context.Conductors.Add(conductor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConductor), new { id = conductor.ConCedula }, conductor);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConductor(string id, Conductor conductor)
        {
            if (id != conductor.ConCedula)
            {
                return BadRequest();
            }

            _context.Entry(conductor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConductor(string id)
        {
            var conductor = await _context.Conductors.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }

            _context.Conductors.Remove(conductor);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
