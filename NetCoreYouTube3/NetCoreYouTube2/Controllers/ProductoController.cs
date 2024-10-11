using Microsoft.AspNetCore.Mvc;
using NetCoreYouTube2.Models;
using NetCoreYouTube2.Recursos;
using Newtonsoft.Json;
using System.Data;

namespace NetCoreYouTube2.Controllers
{
    [ApiController]//Copia y pega (2) mas contlpunto
    [Route("producto")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic ListarProducto()//Antes era 'bool estado' > ()
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Estado", "1")
            };
            DataTable tCategoria = DBDatos.Listar("Categoria_Listar", parametros);
            DataTable tProducto = DBDatos.Listar("Producto_Listar");

            string JsonCategoria = JsonConvert.SerializeObject(tCategoria);
            string JsonProducto = JsonConvert.SerializeObject(tProducto);

            return new
            {
                success = true,
                message = "Exito :D",
                result = new
                {
                    categoria = JsonConvert.DeserializeObject<List<Categoria>>(JsonCategoria),
                    producto = JsonConvert.DeserializeObject<List<Producto>>(JsonProducto),
                }
            };
        }

        [HttpPost]
        [Route("agregar")]
        public dynamic AgregarProducto(Producto producto)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@IDCategoria", producto.IDCategoria),
                new Parametro("@Nombre", producto.Nombre),
                new Parametro("@Precio", producto.Precio),
            };
            //bool exito > dynamic result "esto es por los cambios en DBDatos"
            dynamic result = DBDatos.Ejecutar("Producto_Agregar", parametros);

            //return new
            //{
            //    success = exito,
            //    message = exito ? "Exito" : "Error al guardar",
            //    result = ""
            //};
            //Este pedaso de codigo comentado es como estaba abtes
            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""
            };
        }
    }
}
