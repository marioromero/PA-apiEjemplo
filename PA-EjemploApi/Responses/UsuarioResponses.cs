using PA_EjemploApi.Models;

namespace PA_EjemploApi.Responses
{
    /*retorna una tarea*/
    public class UsuarioResponse : ResponseBase<Usuario>
    {
    }

    /*retorna una lista de tareas*/
    public class UsuariosResponse : ResponseBase<List<Usuario>>
    {
    }

    public class NuevaUsuarioResponse : ResponseBase<bool>
    {
    }
}
