using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PA_EjemploApi.DTO;
using PA_EjemploApi.Models;
using PA_EjemploApi.Responses;
using PA_EjemploApi.Services;
using PA_EjemploApi.Services.Users.Data;

namespace PA_EjemploApi.Controllers
{
    [ApiController]
    [Route("MiApiDeEjemplo/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EjemploDbContext>();
            _usuarioService = new UsuarioService(context);

        }

        [HttpGet("obtener-usuarios")]
        public async Task<ActionResult<UsuariosResponse>> GetUsuarios()
        {
            var result = await _usuarioService.ListaUsuarios();

            var response = new UsuariosResponse
            {
                Data = result.Data,
                Status = result.Status,
                Message = result.Message
            };

            return Ok(response);
        }

        [HttpGet("obtener-usuario")]
        public async Task<ActionResult<UsuarioResponse>> GetUsuario(int id)
        {
            var result = await _usuarioService.ObtenerUsuario(id);

            var response = new UsuarioResponse
            {
                Data = result.Data,
                Status = result.Status,
                Message = result.Message
            };

            return Ok(response);
        }

        [HttpPost("ingresar-usuario")]
        public async Task<ActionResult<NuevaUsuarioResponse>> PostUsuario([FromBody] UsuarioDTO usuario)
        {
            var result = await _usuarioService.IngresarUsuario(usuario);

            var response = new NuevaUsuarioResponse
            {
                Data = result.Status,
                Status = result.Status,
                Message = result.Message
            };

            return Ok(response);
        }

        [HttpPut("editar-usuario/{id}")]
        public async Task<ActionResult<NuevaUsuarioResponse>> PutUsuario(int id, [FromBody] UsuarioDTO usuario)
        {
            var result = await _usuarioService.EditarUsuario(id, usuario);

            var response = new NuevaUsuarioResponse
            {
                Data = result.Status,
                Status = result.Status,
                Message = result.Message
            };

            return Ok(response);
        }

        [HttpDelete("eliminar-usuario/{id}")]
        public async Task<ActionResult<NuevaUsuarioResponse>> DeleteUsuario(int id)
        {
            var result = await _usuarioService.EliminarUsuario(id);

            var response = new NuevaUsuarioResponse
            {
                Data = result.Status,
                Status = result.Status,
                Message = result.Message
            };

            return Ok(response);
        }
    }
}
