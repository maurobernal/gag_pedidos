namespace Front.Models
{
    public class UsuarioModels
    {


        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Legajo { get; set; }

        public DateOnly FechaNac { get; set; }

        public static UsuarioModels BuscarUsuario(int id)
        { 
            List<UsuarioModels> list = new List<UsuarioModels>();
            list.Add(new UsuarioModels { 
                Id = 1, Legajo = 4234, FechaNac = new DateOnly(2001, 01, 21),
                Apellido = "Roza", Nombre = "Joaquin" });

            list.Add(new UsuarioModels
            {
                Id = 2,
                Legajo = 345,
                FechaNac = new DateOnly(1998, 07, 11),
                Apellido = "Bernal",
                Nombre = "Mauro"
            });


            return list.Where(w => w.Id == id).FirstOrDefault();

            //return list.Single(s => s.Id == id);
        }


    }
}
