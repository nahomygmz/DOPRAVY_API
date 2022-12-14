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
    [Route("api/TipoSeguro")]
    [ApiController]
    public class TipoSeguroController : ControllerBase
    {
        private readonly DopravyContext _context;

        public TipoSeguroController(DopravyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSeguro>>> GetTipoSeguros()
        {
            return await _context.TipoSeguros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSeguro>> GetTipoSeguro(string id)
        {
            var tipoSeguro = await _context.TipoSeguros.FindAsync(id);

            if (tipoSeguro == null)
            {
                return NotFound();
            }

            return tipoSeguro;
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPost]
        public async Task<ActionResult<TipoSeguro>> PostTipoSeguro(TipoSeguro tipoSeguro)
        {
            _context.TipoSeguros.Add(tipoSeguro);
            await _context.SaveChangesAsync();
  
            return CreatedAtAction(nameof(GetTipoSeguro), new { id = tipoSeguro.TsDesc }, tipoSeguro);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSeguro(string id, TipoSeguro tipoSeguro)
        {
            if (id != tipoSeguro.TsDesc)
            {
                return BadRequest();
            }

            _context.Entry(tipoSeguro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSeguro(string id)
        {
            var tipoSeguro = await _context.TipoSeguros.FindAsync(id);
            if (tipoSeguro == null)
            {
                return NotFound();
            }

            _context.TipoSeguros.Remove(tipoSeguro);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}