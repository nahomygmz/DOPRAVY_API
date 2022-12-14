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
    [Route("api/Admin")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly DopravyContext _context;

        public AdministradorController(DopravyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdmininistradors()
        {
            return await _context.Administradors.ToListAsync();
        }

        [HttpGet("{NICKNAME}")]
        public async Task<ActionResult<Administrador>> GetAdmininistrador(string NICKNAME)
        {
            var admininistrador = await _context.Administradors.FindAsync(NICKNAME);

            if (admininistrador == null)
            {
                return NotFound();
            }
            return admininistrador;
        }

        [HttpGet("{AdminNickname} {AdminPw}", Name = "GetAdmin")]
        public ActionResult GetCliente(string AdminNickname, string AdminPw)
        {
            try
            {
                var admin = _context.Administradors.FirstOrDefault(option => option.AdminNickname == AdminNickname);
                if (admin == null) return NotFound();

                if (admin.AdminPw == AdminPw)
                {
                    return Ok(admin);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdmininistrador(Administrador admininistrador)
        {
            _context.Administradors.Add(admininistrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdmininistrador), new { id = admininistrador.AdminNickname }, admininistrador);
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpPut("{NICKNAME}")]
        public async Task<IActionResult> PutAdmininistrador(string NICKNAME, Administrador admininistrador)
        {
            if (NICKNAME != admininistrador.AdminNickname)
            {
                return BadRequest();
            }

            _context.Entry(admininistrador).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        [HttpDelete("{NICKNAME}")]
        public async Task<IActionResult> DeleteAdmininistrador(string NICKNAME)
        {
            var admininistrador = await _context.Administradors.FindAsync(NICKNAME);
            if (admininistrador == null)
            {
                return NotFound();
            }

            _context.Administradors.Remove(admininistrador);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
