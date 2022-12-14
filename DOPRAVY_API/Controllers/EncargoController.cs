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
    [Route("api/Encargo")]
    [ApiController]
    public class EncargoController : ControllerBase
    {
        private readonly DopravyContext _context;

        public EncargoController(DopravyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encargo>>> GetEncargos()
        {
            return await _context.Encargos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Encargo>> GetEncargo(decimal id)
        {
            var encargo = await _context.Encargos.FindAsync(id);

            if (encargo == null)
            {
                return NotFound();
            }

            return encargo;
        }


        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPost]
        public async Task<ActionResult<Encargo>> PostEncargo(Encargo encargo)
        {
            _context.Encargos.Add(encargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEncargo), new { id = encargo.EncId }, encargo);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargo(decimal id, Encargo encargo)
        {
            if (id != encargo.EncId)
            {
                return BadRequest();
            }

            _context.Entry(encargo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
   
            return Ok();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargo(decimal id)
        {
            var encargo = await _context.Encargos.FindAsync(id);
            if (encargo == null)
            {
                return NotFound();
            }

            _context.Encargos.Remove(encargo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
