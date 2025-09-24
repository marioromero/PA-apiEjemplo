using Microsoft.EntityFrameworkCore;
using PA_EjemploApi.DTO;
using PA_EjemploApi.Models;
using PA_EjemploApi.Services.Users.Data;

namespace PA_EjemploApi.Services
{
    public class UsuarioService
    {
        private readonly EjemploDbContext _context;

        public UsuarioService(EjemploDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Status, string Message, List<Usuario>? Data)> ListaUsuarios()
        {
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                return (true, "Usuarios obtenidos correctamente", usuarios);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener usuarios: {ex.Message}", null);
            }
        }

        public async Task<(bool Status, string Message, Usuario? Data)> ObtenerUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                if (usuario == null)
                    return (false, "Usuario no encontrado", null);

                return (true, "Usuario obtenido correctamente", usuario);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener usuario: {ex.Message}", null);
            }
        }

        public async Task<(bool Status, string Message)> IngresarUsuario(UsuarioDTO usuarioDto)
        {
            try
            {
                var anioActual = DateTime.Now.Year;

                var usuario = new Usuario
                {
                    Nombre = usuarioDto.Nombre,
                    Apellido = usuarioDto.Apellido,
                    Email = usuarioDto.Email,
                    RolId = usuarioDto.RolId,
                    Password = $"{usuarioDto.Nombre}{usuarioDto.Apellido}{anioActual}"
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return (true, "Usuario ingresado correctamente");
            }
            catch (Exception ex)
            {
                return (false, $"Error al ingresar usuario: {ex.Message}");
            }
        }

        public async Task<(bool Status, string Message)> EditarUsuario(int id, UsuarioDTO usuarioDto)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                if (usuario == null)
                    return (false, "Usuario no encontrado");

                usuario.Nombre = usuarioDto.Nombre;
                usuario.Apellido = usuarioDto.Apellido;
                usuario.Email = usuarioDto.Email;
                usuario.RolId = usuarioDto.RolId;

                // Recalcular password cada vez que se edite
                var anioActual = DateTime.Now.Year;
                usuario.Password = $"{usuarioDto.Nombre}{usuarioDto.Apellido}{anioActual}";

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return (true, "Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                return (false, $"Error al editar usuario: {ex.Message}");
            }
        }

        public async Task<(bool Status, string Message)> EliminarUsuario(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                if (usuario == null)
                    return (false, "Usuario no encontrado");

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return (true, "Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar usuario: {ex.Message}");
            }
        }
    }
}
