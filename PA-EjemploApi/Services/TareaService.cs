using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA_EjemploApi.DTO;
using PA_EjemploApi.Models;
using PA_EjemploApi.Services.Users.Data;

namespace PA_EjemploApi.Services
{
    public class TareaService
    {
        private readonly EjemploDbContext context;

        public TareaService( EjemploDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Tarea>> ListaTareas()
        {
            List<Tarea> tareas = await context.Tareas.ToListAsync();

            return tareas;
        }

        public async Task<Tarea> ObtenerTarea(int id)
        {
            Tarea tarea = await context.Tareas.FindAsync(id);

            return tarea;
        }

        public async Task<bool> IngresarTarea(TareaDTO tarea)
        {

            try
            {
                var nuevaTarea = new Tarea
                {
                    Descripcion = tarea.Descripcion,
                    FechaInicio = DateTime.Now,
                    FechaIngreso = DateTime.Now,
                    Estado = "Pendiente",
                    Responsable = tarea.Responsable
                };

                context.Tareas.Add(nuevaTarea);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
    }
}
