using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreYouTube.Models;
using System.Security.Claims;

namespace NetCoreYouTube.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
                {
                new Cliente
                {
                id = "1",
                    correo = "go@gh.com",
                    edad = "17",
                    nombre = "Bernando"
                },
                new Cliente
                {
                    id = "2",
                    correo = "go@gh.com",
                    edad = "17",
                    nombre = "Bernando"
                }
            };
            return clientes;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(int codigo)
        {
            //Obtines el cliente de la db
            return new Cliente
            {
                id = codigo.ToString(),
                correo = "go@gh.com",
                edad = "17",
                nombre = "Bernando"
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";

            return new
            {
                success = true,
                message = "Cliente guardado",
                results = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        //[Authorize] //En postman no eliminar>
        public dynamic eliminarCliente(Cliente cliente)
        {
            //Eliminar al cliente en la db
            //En el video ya no se utiliza esta parte
            //string Token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            
            //if(Token != "marco123")
            //{
              //  return new
                //{
                    //success = false,
                  //  message = "Token incorrecto",
                //    results = ""
              //  };
            //}

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            Usuario usuario = rToken.result;

            if(usuario.rol != "administrador")
            {
                return new
                {
                    success = false,
                    message = "No tienes permiso para elimar clientes",
                    results = ""
                };
            }
            
            return new
            {
                success = true,
                message = "Cliente Eliminado",
                results = cliente
            };
        }
    }

}
