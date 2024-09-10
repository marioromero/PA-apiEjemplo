using Microsoft.AspNetCore.Mvc;
using PA_EjemploApi.DTO;
using PA_EjemploApi.Models;

namespace PA_EjemploApi.Services
{
    public class TareaService
    {
        public async Task<List<Tarea>> ListaTareas()
        {
            List<Tarea> tareas = new List<Tarea>();

            //aquí se simula la carga de tareas desde una base de datos
            tareas = Tarea.CargarTareas();

            return tareas;
        }

        public async Task<Tarea> ObtenerTarea(int id)
        {
            Tarea tarea = new Tarea();

            //aquí se simula la carga de una tarea desde una base de datos
            tarea = Tarea.CargarTarea();

            return tarea;
        }

        public async Task<bool> IngresarTarea(TareaDTO tarea)
        {
            //aquí se simula la inserción de una tarea en una base de datos

            return true;
        }
    }
}
