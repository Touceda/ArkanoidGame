using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ArkanoidBaseDeDatos
{
    public class Usuario
    {
        private ConexionSql conexion;
        public ConexionSql Conexion { get { return conexion; } }

        private bool usuarioEncontrado = false;
        public bool UsuarioEncontrado { get { return usuarioEncontrado; } }

        private int nivelActual = 1;
        public int NivelActual { get { return nivelActual; } }

        private int puntuacionActual = 0;
        public int PuntuacionActual { get { return puntuacionActual; } }

        public Usuario()
        {
            conexion = new ConexionSql();
        }

        public string BuscarUsuario(string usuario, string contraseña)
        {
            try
            {
                string mensaje = "";
                conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "BuscarUsuario";
                    using (var Lector = comando.ExecuteReader())
                    {
                        while (Lector.Read())
                        {
                            string sqlUsuario = Lector.GetString(0).ToString();
                            string sqlContraseña = Lector.GetString(1).ToString();

                            if (sqlUsuario == usuario)
                            {
                                if (sqlContraseña == contraseña)
                                {
                                    this.usuarioEncontrado = true;
                                    this.nivelActual = int.Parse((Lector["NivelActual"].ToString()));
                                    this.puntuacionActual = int.Parse((Lector["PuntuacionActual"].ToString()));
                                    mensaje = "Usuario Encontrado";
                                }
                                else
                                {
                                    mensaje = "La Contraseña es incorrecta";
                                }
                            }
                        }
                    }
                }

                conexion.Desconectar();
                if (mensaje == "Usuario Encontrado" || mensaje == "La Contraseña es incorrecta") 
                {
                    return mensaje;
                }
                return "No se encontro registros del Usuario";
            }
            catch (Exception)
            {
                return "Ocurrio un error";
            }        
        }//Reviso si el usuario existe o no y devuelvo un mensaje personalizado
        public DataTable ObtenerUsuario()//Extraigo la tabla de usuarios
        {
            DataTable tabla = new DataTable();
            Conexion.Conectar();
            using (SqlCommand comando = new SqlCommand())
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = Conexion.Conection;
                comando.CommandText = "BuscarUsuario";
                using (SqlDataAdapter DA = new SqlDataAdapter())
                {
                    DA.SelectCommand = comando; //Le paso el procAlmacenado y la conexion al comando
                    DA.Fill(tabla); //Ejecuto comando y le paso la tabla para rellenar
                }
            }
            Conexion.Desconectar();
            return tabla;
        }
        public string CargarUsuario(string usuario, string contraseña)
        {
            try
            {
                conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "BuscarUsuario";
                    using (var Lector = comando.ExecuteReader())
                    {
                        while (Lector.Read())
                        {
                            string sqlUsuario = Lector.GetString(0).ToString();

                            if (sqlUsuario == usuario)
                            {
                                return "Este nombre de Usuario ya existe, seleccione otro";
                            }
                        }                       
                    }
                }
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    //comando.CommandText = "Insert Into RegistroDeUsuarios (Usuario,Contraseña) values (@usuario,@contra)";
                    comando.CommandText ="RegistrarUsuario";
                    comando.Connection = Conexion.Conection;
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contra", contraseña);
                    comando.Parameters.AddWithValue("@nivel", 1);
                    comando.Parameters.AddWithValue("@puntuacion", 0);
                    comando.ExecuteNonQuery();
                }


                conexion.Desconectar();
                return "Felicidades Usuario Registrado con exito";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }//Creo nuevos usuarios
        public void ActualizarUsuario(string usuario, int nivel, int pts)//Actualizo usuarios que ya existen
        {
            try
            {
                conexion.Conectar();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Connection = Conexion.Conection;
                    comando.CommandText = "ActualizarUsuario";
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@nivelactual", nivel);
                    comando.Parameters.AddWithValue("@puntuacionactual", pts);
                    comando.ExecuteNonQuery();
                }
                conexion.Desconectar();
            }
            catch (Exception)
            {
                conexion.Desconectar();
                return;
            }
        }

    }
}
