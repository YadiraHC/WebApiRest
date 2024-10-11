using Microsoft.AspNetCore.Mvc;
using NetCoreYouTube2.Models;

namespace NetCoreYouTube2.Controllers
{
    //(2)
    [ApiController]
    [Route("cliente")]//direccion/cliente/
    //(1)
    public class ClienteContoller : ControllerBase
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
        public dynamic eliminarCliente(Cliente cliente)
        {
            //Requeste para el header
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if(token != "marco123")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
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
