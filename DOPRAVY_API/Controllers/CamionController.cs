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
    [Route("api/Camion")]
    [ApiController]
    public class CamionController : ControllerBase
    {
        private readonly DopravyContext _context;

        public CamionController(DopravyContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camion>>> GetCamions()
        {
            return await _context.Camions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Camion>> GetCamion(string id)
        {
            var camion = await _context.Camions.FindAsync(id);
            if (camion.CamStatus == "Mantenimiento" || camion.CamStatus == "Inactivo") return BadRequest();
            if (camion == null)
            {
                return NotFound();
            }

            return camion;
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPost]
        public async Task<ActionResult<Camion>> PostCamion(Camion camion)
        {
            _context.Camions.Add(camion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCamion), new { id = camion.CamUnidad }, camion);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCamion(string id, Camion camion)
        {
            if (id != camion.CamUnidad)
            {
                return BadRequest();
            }

            _context.Entry(camion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamion(string id)
        {
            var camion = await _context.Camions.FindAsync(id);
            if (camion == null)
            {
                return NotFound();
            }

            _context.Camions.Remove(camion);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
