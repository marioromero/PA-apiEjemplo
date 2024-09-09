using Microsoft.AspNetCore.Mvc;
using PA_EjemploApi.DTO;
using PA_EjemploApi.Models;

namespace PA_EjemploApi.Controllers
{
    [ApiController]
    [Route("MiApiDeEjemplo/[controller]")]
    public class TareaController : Controller
    {

        [HttpGet("obtener-tarea")]
        public ActionResult<Tarea> GetTarea()
        {

            var tarea = Tarea.CargarTarea();

            return Ok(tarea);
        }

        [HttpPost("ingresar-tarea")]
        public ActionResult IngresarTarea([FromBody]  TareaDTO objeto)
        {

            //var tarea = Tarea.CargarTarea();

            return Ok();
        }







    }
}
