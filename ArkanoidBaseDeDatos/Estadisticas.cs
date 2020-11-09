using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ArkanoidBaseDeDatos
{
    public class Estadisticas
    {
        private ConexionSql conexion;
        public ConexionSql Conexion { get { return conexion; } }

        public Estadisticas()
        {
            conexion = new ConexionSql();
        }

        public DataTable ObtenerEstadisticasDeUsuario()//Obtengo una tabla con las estadisticas de los usuarios
        {
            try
            {
                DataTable tabla = new DataTable();
                Conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "BuscarEstadisticas";
                    using (SqlDataAdapter DA = new SqlDataAdapter())
                    {
                        DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
                        DA.Fill(tabla); //Ejecuto comando y le paso la tabla para rellenar
                    }  
                }

                Conexion.Desconectar();
                return tabla;
            }
            catch (Exception)
            {
                return null;
            }
        }  

        public bool CargarEstadisticasDeUsuario(List<SqlParameter> stats)
        {
            try
            {
                Conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "CrearEstadisticas";
                    comando.Parameters.AddRange(stats.ToArray());
                    comando.ExecuteNonQuery();
                }
                Conexion.Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }//Creo por primera ves las estadisticas de una cuenta nueva

        public void ActualizarEstadisticas(List<SqlParameter> stats)//Actualizo las estadisticas de una cuenta
        {
            try
            {
                Conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "ActualizarEstadisticas";
                    comando.Parameters.AddRange(stats.ToArray());
                    comando.ExecuteNonQuery();
                }
                Conexion.Desconectar();
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
