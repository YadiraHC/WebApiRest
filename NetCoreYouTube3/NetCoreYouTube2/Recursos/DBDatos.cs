using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace NetCoreYouTube2.Recursos
{
    public class DBDatos
    {                                      //"Data Source=DESKTOP-OVDKE80;Initial Catalog=ProFindr_Dev2 ;Integrated Security=True;Encrypt=False;"
        public static string cadenaConexion = "Data Source=Lap\\SQLEXPRESS; Initial Catalog=Test; Integrated Security=True;Encrypt=False;";//User ID=; Password=
        public static DataSet ListarTablas(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);//sqlConnection ctrol + .

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable Listar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }
        //public static bool Ejecutar() > public static dynamic Ejecutar
        public static dynamic Ejecutar(string nombreProcedimiento, List<Parametro> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                //return (i > 0) ? true : false;
                bool exito =  (i > 0) ? true : false;

                return new
                {
                    exito = exito,
                    mensaje = "Exito"
                };
            }
            catch (Exception ex)
            {
                //esto se agrego como mejora
                return new
                {
                    exito = false,
                    mensaje = ex.Message
                };
                //esto se comento por l mejora
                //return false;
            }
            finally
            {
                conexion.Close();
            }
        }
    }

}
