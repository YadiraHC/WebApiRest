using System.Security.Claims;

namespace NetCoreYouTube.Models
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; } 

        //
        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0) 
                {
                    return new
                    {
                        success = false,
                        message = "Verifica que el token sea correcto",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                Usuario usuario = Usuario.DB().FirstOrDefault(x => x.isUsuario == id);

                return new
                {
                    success = true,
                    message = "Exito :D",
                    result = usuario
                };
            }
            catch (Exception ex) 
            {
                return new
                {
                    success = false,
                    message = "Catch: "+ex.Message,
                    result = ""
                };
            }
        }
    }
}
