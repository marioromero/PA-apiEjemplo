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
    public class TareaController : Controller
    {
        private readonly TareaService _tareaService;

        public TareaController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<EjemploDbContext>();
            _tareaService = new TareaService(context);

        }

        [HttpGet("obtener-tareas")]
        public async Task<ActionResult<TareasResponse>> GetTareas()
        {
            var tareas = await _tareaService.ListaTareas();

            var response = new TareasResponse
            {
                Data = tareas,
                Code = 200,
                Message = "Tareas obtenidas correctamente"
            };

            return Ok(response);
        }

        [HttpGet("obtener-tarea")]
        public async Task<ActionResult<TareaResponse>> GetTarea(int id)
        {
           var tarea = await _tareaService.ObtenerTarea(id);

            var response = new TareaResponse
              {
                Data = tarea,
                Code = 200,
                Message = "Tarea obtenida correctamente"
              };

            return Ok(response);

        }

        [HttpPost("ingresar-tarea")]
        public async Task<ActionResult<NuevaTareaResponse>> PostTarea([FromBody] TareaDTO tarea)
        {
            var ingreso = await _tareaService.IngresarTarea(tarea);

            var response = new NuevaTareaResponse
            {
                Data = ingreso,
                Code = 200,
                Message = "Tarea ingresada correctamente"
            };

            return Ok(response);
        }

    }
}
