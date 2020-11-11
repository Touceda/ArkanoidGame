using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ArkanoidBaseDeDatos
{
    public class InicioCierreDeSesion
    {
        private ConexionSql conexion;
        public ConexionSql Conexion { get { return conexion; } }

        private int id;

        private string usuario;
        public string Usuario { get { return usuario; } set { value = usuario; } }

        private string inicioDeSesion;
        public string InicioDeSesion { get { return inicioDeSesion; } set { value = inicioDeSesion; } }
        public InicioCierreDeSesion(string nombre)
        {
            this.usuario = nombre;
            inicioDeSesion = DateTime.Now.ToString();
            conexion = new ConexionSql();
        }

        public void RegistrarNuevoInicio()
        {
            try
            {
                conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    int idMasAlto = 0;
                    DataTable Ids = new DataTable();
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "BuscarIDRegistroDeLogeos";
                    using (SqlDataAdapter DA = new SqlDataAdapter())
                    {
                        DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
                        DA.Fill(Ids); //Ejecuto comando y le paso la tabla para rellenar
                    }
                    idMasAlto = IdMasAlto(Ids);
                    idMasAlto++;
                    this.id = idMasAlto;
                }

                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "InsertarRegistroDeLogeos";
                    comando.Parameters.AddWithValue("@id",this.id );
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@iniciodesesion", this.inicioDeSesion);
                    comando.Parameters.AddWithValue("@cierredesesion", DateTime.Now.ToString());
                    comando.ExecuteNonQuery();
                }
                conexion.Desconectar();     
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private int IdMasAlto(DataTable IDs)
        {
            int idMasAlto = 0;
            foreach (DataRow fila in IDs.Rows)
            {              
                int id = int.Parse(fila[0].ToString());

                if (id>idMasAlto)
                {
                    idMasAlto = id;
                }
            }
            return idMasAlto;
        }

        public void ActualizarInicioCierre()//Actualizo la hora de cierre de sesion
        {
            try
            {
                Conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "ActualizarRegistroDeLogeos";
                    comando.Parameters.AddWithValue("@id", this.id);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@iniciodesesion", this.inicioDeSesion);
                    comando.Parameters.AddWithValue("@cierredesesion", DateTime.Now.ToString());
                    comando.ExecuteNonQuery();
                }
                Conexion.Desconectar();
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public DataTable ObtenerLogs()
        {
            try
            {
                DataTable stats = new DataTable();
                conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "BuscarRegistroDeLog";
                    comando.Parameters.AddWithValue("@usuario", this.usuario);
                    using (SqlDataAdapter DA = new SqlDataAdapter())
                    {
                        DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
                        DA.Fill(stats); //Ejecuto comando y le paso la tabla para rellenar
                    }
                }
                conexion.Desconectar();
                return stats;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
