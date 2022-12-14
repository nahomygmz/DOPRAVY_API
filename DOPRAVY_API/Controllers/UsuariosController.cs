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
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DopravyContext _context;

        public UsuariosController(DopravyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        

        //usuarios login

       [HttpGet("{cliCedula}")]
        public ActionResult GetUsuario(string cliCedula, string cliPw)
        {
            try
            {
                var user = _context.Clientes.FirstOrDefault(option => option.CliCedula == cliCedula);
                if (user == null) return NotFound();

                if (user.CliPw == cliPw)
                {
                    return Ok(user);
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
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.CliCedula }, usuario);
        }

       

        private bool UsuarioExists(string id)
        {
            return _context.Usuarios.Any(e => e.CliCedula == id);
        }
    }
}
