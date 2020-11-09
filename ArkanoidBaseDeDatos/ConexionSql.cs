using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ArkanoidBaseDeDatos
{
    public class ConexionSql
    {
        private SqlConnection conection;
        public SqlConnection Conection { get { return conection; } }
        private string sqlDirecction = @"Data Source=DESKTOP-4EMC1D1;Initial Catalog=Arkanoid;Integrated Security=True";
        public SqlConnection Conectar()
        {
            //Evita crear una nueva conexion cunado ya tenemos una activa
            if (conection != null && conection.State == System.Data.ConnectionState.Open)
            {
                return conection;
            }

            conection = new SqlConnection();
            conection.ConnectionString = sqlDirecction;
            conection.Open();
            return conection;
        }
        public void Desconectar()
        {
            conection.Close();
            conection.Dispose();
            GC.Collect();
        }


        public SqlParameter CrearParametro(string tipo, string valor)
        {
            SqlParameter parametro = new SqlParameter(tipo, valor);
            parametro.SqlDbType = System.Data.SqlDbType.Text;
            return parametro;
        }
        public SqlParameter CrearParametro(string tipo, int valor)
        {
            SqlParameter parametro = new SqlParameter(tipo, valor);
            parametro.SqlDbType = System.Data.SqlDbType.Int;
            return parametro;
        }

    }
}
