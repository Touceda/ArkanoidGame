using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ArkanoidBaseDeDatos
{
    public class InicioCierreDeSesion
    {
        private ConexionSql conexion;
        public ConexionSql Conexion { get { return conexion; } }

        private int id;

        private string nombre;
        public string Nombre { get { return nombre; } set { value = nombre; } }

        private string inicioDeSesion;
        public string InicioDeSesion { get { return inicioDeSesion; } set { value = inicioDeSesion; } }
        public InicioCierreDeSesion(string nombre)
        {
            this.nombre = nombre;
            inicioDeSesion = DateTime.Now.ToString();
            conexion = new ConexionSql();
        }

        public void RegistrarNuevoInicio()
        {
            //SQLCommand.ExecuteScalar()
            try
            {
                conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "BuscarIDRegistroDeLogeos";
                    int idMasAlto = Convert.ToInt32(comando.ExecuteScalar());
                    idMasAlto++;                 
                }

                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "InsertarRegistroDeLogeos";
                    comando.Parameters.AddWithValue("@usuario", );
                    comando.Parameters.AddWithValue("@nivelactual", nivel);
                    comando.Parameters.AddWithValue("@puntuacionactual", pts);
                    comando.ExecuteNonQuery();
                }

                conexion.Desconectar();     
            }
            catch (Exception ex)
            {

            }
        }

        //public DataTable ActualizarInicioCierre()//Extraigo la tabla de usuarios
        //{
        //    DataTable tabla = new DataTable();
        //    Conexion.Conectar();
        //    using (SqlCommand comando = new SqlCommand())
        //    {
        //        comando.CommandType = System.Data.CommandType.StoredProcedure;
        //        comando.Connection = Conexion.Conection;
        //        comando.CommandText = "BuscarUsuario";
        //        using (SqlDataAdapter DA = new SqlDataAdapter())
        //        {
        //            DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
        //            DA.Fill(tabla); //Ejecuto comando y le paso la tabla para rellenar
        //        }
        //    }
        //    Conexion.Desconectar();
        //    return tabla;
        //}
        //public string ObtenerInformacion(string usuario, string contraseña)
        //{
        //    try
        //    {
        //        conexion.Conectar();
        //        using (SqlCommand comando = new SqlCommand())
        //        {
        //            comando.CommandType = System.Data.CommandType.StoredProcedure;
        //            comando.Connection = Conexion.Conection;
        //            comando.CommandText = "BuscarUsuario";
        //            using (var Lector = comando.ExecuteReader())
        //            {
        //                while (Lector.Read())
        //                {
        //                    string sqlUsuario = Lector.GetString(0).ToString();

        //                    if (sqlUsuario == usuario)
        //                    {
        //                        return "Este nombre de Usuario ya existe, seleccione otro";
        //                    }
        //                }
        //            }
        //        }
        //        using (SqlCommand comando = new SqlCommand())
        //        {
        //            comando.CommandType = System.Data.CommandType.StoredProcedure;
        //            //comando.CommandText = "Insert Into RegistroDeUsuarios (Usuario,Contraseña) values (@usuario,@contra)";
        //            comando.CommandText = "RegistrarUsuario";
        //            comando.Connection = Conexion.Conection;
        //            comando.Parameters.AddWithValue("@usuario", usuario);
        //            comando.Parameters.AddWithValue("@contra", contraseña);
        //            comando.Parameters.AddWithValue("@nivel", 1);
        //            comando.Parameters.AddWithValue("@puntuacion", 0);
        //            comando.ExecuteNonQuery();
        //        }


        //        conexion.Desconectar();
        //        return "Felicidades Usuario Registrado con exito";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}//Creo nuevos usuarios
        //public void ActualizarUsuario(string usuario, int nivel, int pts)//Actualizo usuarios que ya existen
        //{
        //    try
        //    {
        //        conexion.Conectar();
        //        using (SqlCommand comando = new SqlCommand())
        //        {
        //            comando.CommandType = System.Data.CommandType.StoredProcedure;
        //            comando.Connection = Conexion.Conection;
        //            comando.CommandText = "ActualizarUsuario";
        //            comando.Parameters.AddWithValue("@usuario", usuario);
        //            comando.Parameters.AddWithValue("@nivelactual", nivel);
        //            comando.Parameters.AddWithValue("@puntuacionactual", pts);
        //            comando.ExecuteNonQuery();
        //        }
        //        conexion.Desconectar();
        //    }
        //    catch (Exception)
        //    {
        //        conexion.Desconectar();
        //        return;
        //    }
        //}
    }
}
