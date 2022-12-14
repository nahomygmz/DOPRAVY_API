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
    [Route("api/Sexo")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly DopravyContext _context;

        public SexoController(DopravyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sexo>>> GetSexos()
        {
            return await _context.Sexos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sexo>> GetSexo(string id)
        {
            var sexo = await _context.Sexos.FindAsync(id);

            if (sexo == null)
            {
                return NotFound();
            }

            return sexo;
        }
        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPost]
        public async Task<ActionResult<Sexo>> PostSexo(Sexo sexo)
        {
            _context.Sexos.Add(sexo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSexo), new { id = sexo.SexoDesc }, sexo);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSexo(string id, Sexo sexo)
        {
            if (id != sexo.SexoDesc)
            {
                return BadRequest();
            }

            _context.Entry(sexo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSexo(string id)
        {
            var sexo = await _context.Sexos.FindAsync(id);
            if (sexo == null)
            {
                return NotFound();
            }

            _context.Sexos.Remove(sexo);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
