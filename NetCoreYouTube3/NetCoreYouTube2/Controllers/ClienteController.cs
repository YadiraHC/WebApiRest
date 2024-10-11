using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreYouTube2.Models;
using System.Security.Claims;

namespace NetCoreYouTube2.Controllers
{
    //(2)
    [ApiController]
    [Route("cliente")]//direccion/cliente/
    //(1)
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]//direccion/cliente/listar ()
        public dynamic listarCliente()
        {
            ///return new
            //{
            //    nombre = "Jesus",
            //    edad = "33"
            //};

            //listatemporal
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "Bernando@gmail.com",
                    edad = "19",
                    nombre = "Bernando"
                },
                new Cliente
                {
                    id = "2",
                    correo = "Bernando@gmail.com",
                    edad = "19",
                    nombre = "Bernando"
                },

            };
            return clientes;
        }


        [HttpGet]
        [Route("listarxid")] //direccion/cliente/listar ()
        public dynamic listarClientexid(int codigo)//recibismos el parametro que antes era _id
        {
            return new Cliente
            {
                id = codigo.ToString(),
                correo = "Bernando@gmail.com",
                edad = "19",
                nombre = "Bernando"
            };
        }

        [HttpPost]//3
        [Route("guardar")]//direccion/cliente/guardarr
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.id = "3";

            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpPost]//(4)
        [Route("eliminar")]//direccion/cliente/eliminar
        [Authorize]
        public dynamic eliminarCliente(Cliente cliente)
        {
            //Requeste para el header
            //se comento por parte del video 2
            //2 string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            //2if(token != "marco123")
            //2{
            //2    return new
            //2    {
            //2        success = false,
            //2        message = "token incorrecto",
            //2       result = ""
            //2    };
            //2}


            //Luego ve a Jwt.cs
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            Usuario usuario = rToken.result;

            if (usuario.rol != "administrador")
            {
                return new
                {
                    success = false,
                    message = "No tienes permiso para eliminar clientes",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "Cliente eliminado",
                result = cliente
            };
        }
    }
}
