using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArkanoidBaseDeDatos;
using ArkanoidMotor;

namespace ArkanoidInterfaz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private string usuario;
        public string Usuario { get { return usuario; } }

        private string contraseña;
        public string Contraseña { get { return contraseña; } }


        Usuario ConexionUsuarios;
        Estadisticas ConexionStats;
        public Jugador Player;
        PlayerStats Stats;
       
        private void Login_Load(object sender, EventArgs e)
        {
            ConexionUsuarios = new Usuario();
            ConexionStats = new Estadisticas();
     

            txtUsuario.Text = "Nicolas";
            txtContraseña.Text = "holamundo123";
        }

        private void btbIniciarCuenta_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            string mensaje = ConexionUsuarios.BuscarUsuario(Usuario, Contraseña);
            lblErrorDeLog.Text = mensaje;
            if (ConexionUsuarios.UsuarioEncontrado == true && mensaje == "Usuario Encontrado")
            {
                DataTable tableStats = ConexionStats.ObtenerEstadisticasDeUsuario(); //Obtengo todas las stats de los usuarios
                Stats = BuscarEstadisticasDeJugador(tableStats); //Busco las stats que me interesan (El usuario que va a jugar)

                DataTable tablePlayers = ConexionUsuarios.ObtenerUsuario();//Obtengo todos los jugadores registrados
                Player = BuscarJugador(tablePlayers);//Busco el player que va a jugar


                //Player = new Jugador(mensaje, Stats,ConexionUsuarios.NivelActual, ConexionUsuarios.PuntuacionActual);
                this.Close();
            }
        }

        private PlayerStats BuscarEstadisticasDeJugador(DataTable table)
        {
            foreach (DataRow fila in table.Rows)
            {
                string usuario = fila[0].ToString();
                if (usuario == this.usuario)
                {
                    int pjugadas = int.Parse(fila[1].ToString());
                    int nivelesCompletos = int.Parse(fila[2].ToString());
                    int nivelesPerdidos = int.Parse(fila[3].ToString());
                    int victorias = int.Parse(fila[4].ToString());
                    int derrotas = int.Parse(fila[5].ToString());
                    int puntuacionMasAlta = int.Parse(fila[6].ToString());
                    string tiempoJugado = fila[7].ToString();
                    return new PlayerStats(pjugadas,nivelesCompletos,nivelesPerdidos,victorias,derrotas,puntuacionMasAlta,tiempoJugado);
                }         
            }
            return null;
        }
        private Jugador BuscarJugador(DataTable table)
        {
            foreach (DataRow fila in table.Rows)
            {
                string usuario = fila[0].ToString();
                if (usuario == this.usuario)
                {
                    int nivelActual = int.Parse(fila[2].ToString());
                    int puntuacionActual = int.Parse(fila[3].ToString());                 
                    return new Jugador(this.usuario,Stats,nivelActual,puntuacionActual);
                }
            }
            return null;
        }


        private void btbRegistro_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            if (usuario.Count() <= 4 && contraseña.Count() <= 4) 
            {
                lblErrorDeLog.Text = "Credenciales de registro muy cortas";
                return;
            }

            if (usuario.Count() >= 21 && contraseña.Count() >= 21)
            {
                lblErrorDeLog.Text = "Credenciales de registro muy largas, no puede hbaer mas de 20 caracteres";
                return;
            }

            string mensaje = ConexionUsuarios.CargarUsuario(Usuario, Contraseña);//Mando a crear el nuevo usuario

            if (mensaje == "Felicidades Usuario Registrado con exito") //Si se creo con exito le creo una tabla de estadisticas y las colpeto con stats iniciales
            {
                List<SqlParameter> stats = new List<SqlParameter>();
                stats.Add(ConexionStats.Conexion.CrearParametro("@usuario", usuario));
                stats.Add(ConexionStats.Conexion.CrearParametro("@partidasjugadas", 0));
                stats.Add(ConexionStats.Conexion.CrearParametro("@nivelescompletos", 0));
                stats.Add(ConexionStats.Conexion.CrearParametro("@nivelesperdidos", 0));
                stats.Add(ConexionStats.Conexion.CrearParametro("@victorias", 0));
                stats.Add(ConexionStats.Conexion.CrearParametro("@derrotas", 0));
                stats.Add(ConexionStats.Conexion.CrearParametro("@puntuacionmasalta", 0));
                stats.Add(ConexionStats.Conexion.CrearParametro("@tiempojugado","00:00:00:00"));
                ConexionStats.CargarEstadisticasDeUsuario(stats);
            }
            lblErrorDeLog.Text = mensaje;
        }
    }
}
