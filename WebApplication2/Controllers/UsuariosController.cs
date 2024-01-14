using WebApplication2.Entities;
using WebApplication2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("getusuariolist")]
        public async Task<List<Usuario>> GetUsuarioListAsync()
        {
            try
            {
                return await usuarioService.GetUsuarioListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getusuariobyid")]
        public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int Id)
        {
            try
            {
                var response = await usuarioService.GetUsuarioByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addusuario")]
        public async Task<IActionResult> AddUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await usuarioService.AddUsuarioAsync(usuario);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updateusuario")]
        public async Task<IActionResult> UpdateUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await usuarioService.UpdateUsuarioAsync(usuario);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deleteusuario")]
        public async Task<int> DeleteUsuarioAsync(int Id)
        {
            try
            {
                var response = await usuarioService.DeleteUsuarioAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}