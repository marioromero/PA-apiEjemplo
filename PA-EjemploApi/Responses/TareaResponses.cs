using PA_EjemploApi.Models;

namespace PA_EjemploApi.Responses
{
    /*retorna una tarea*/
    public class TareaResponse : ResponseBase<Tarea>
    {
    }

    /*retorna una lista de tareas*/
    public class TareasResponse : ResponseBase<List<Tarea>>
    {
    }

    public class NuevaTareaResponse : ResponseBase<bool>
    {
    }
}
