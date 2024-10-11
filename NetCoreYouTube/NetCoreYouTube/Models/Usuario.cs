namespace NetCoreYouTube.Models
{
    public class Usuario
    {
        public string isUsuario {  get; set; }
        public string usuario { get; set; }
        public string passrowd { get; set; }
        public string rol { get; set; }

        public static List<Usuario> DB()
        {
            var list = new List<Usuario>()
            {
                new Usuario
                {
                    isUsuario = "1",
                    usuario = "Mateo",
                    passrowd = "123",
                    rol = "empleado"
                },
                new Usuario
                {
                    isUsuario = "2",
                    usuario = "Marcos",
                    passrowd = "123",
                    rol = "empleado"
                },
                new Usuario
                {
                    isUsuario = "3",
                    usuario = "Lucas",
                    passrowd = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    isUsuario = "4",
                    usuario = "Juan",
                    passrowd = "123",
                    rol = "administrador"
                },
            };
            return list;
        }
    }
}
