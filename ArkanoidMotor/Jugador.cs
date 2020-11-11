using ArkanoidBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidMotor
{
    public class Jugador
    {

        private PlayerStats stats;
        public PlayerStats Stats { get { return stats; } set { stats = value; } }

        private string nombre;
        public string Nombre { get { return nombre; } set { nombre = value; } }

        private int nivelActual;
        public int NivelActual { get { return nivelActual; } set { nivelActual = value; } }

        private int puntuacion;
        public int Puntuacion { get { return puntuacion; } set { puntuacion = value; } }

        private Usuario ConexionUsuario;
        private Estadisticas ConexionEstadisticas;
        private InicioCierreDeSesion ConexionLog;
        public Jugador(string usuario, PlayerStats loadStats, int nivel = 1, int puntuacion = 0)
        {
            this.stats = loadStats;
            this.nombre = usuario;
            this.nivelActual = nivel;
            this.puntuacion = puntuacion;

            ConexionUsuario = new Usuario();
            ConexionEstadisticas = new Estadisticas();
            ConexionLog = new InicioCierreDeSesion(this.nombre);
        }

        public void ActualizarCuentaStats()
        {
            ConexionUsuario.ActualizarUsuario(this.nombre, this.nivelActual, this.puntuacion);
            List<SqlParameter> stats = new List<SqlParameter>();
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@usuario", this.nombre));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@partidasjugadas", this.stats.PartidasJugadas));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@nivelescompletos", this.stats.NivelesCompletos));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@nivelesperdidos", this.stats.NivelesPerdidos));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@victorias", this.stats.Victorias));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@derrotas", this.stats.Derrotas));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@puntuacionmasalta", this.stats.MaximaPuntuacion));
            stats.Add(ConexionUsuario.Conexion.CrearParametro("@tiempojugado", this.stats.TiempoJugado));
            ConexionEstadisticas.ActualizarEstadisticas(stats);
            ActualizarCierre();
        }

        public void CargarNuevoInicioCierreDeSesion()
        {
            ConexionLog.RegistrarNuevoInicio();
        }

        public void ActualizarCierre()
        {
            ConexionLog.ActualizarInicioCierre();
        }

        public DataTable ObtenerStats()
        {
            return ConexionEstadisticas.ObtenerEstadisticasDeUsuario();      
        }

        public DataTable ObtenerListaDeLogs()
        {
            return ConexionLog.ObtenerLogs();
        }

    }
}
