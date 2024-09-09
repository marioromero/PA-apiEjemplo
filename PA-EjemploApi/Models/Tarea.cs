namespace PA_EjemploApi.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }

        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; }
        public int Responsable { get; set; }

        public static Tarea CargarTarea()
        {
            return new Tarea
            {
                Id = 1,
                Descripcion = "1",
                FechaInicio = DateTime.Now,
                FechaIngreso = DateTime.Now,
                Estado = "Pendiente",
                Responsable = 5,
            };

        }
    }


}
