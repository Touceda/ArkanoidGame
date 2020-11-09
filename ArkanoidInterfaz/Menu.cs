using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArkanoidMotor;
using ArkanoidBaseDeDatos;

namespace ArkanoidInterfaz
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public Jugador Player;
        Login FormLogin = new Login();
        Form1 Juego;

        Instrucciones instrucciones = new Instrucciones();

        private void Menu_Load(object sender, EventArgs e)
        {
            FormLogin.ShowDialog();
            if (FormLogin.Player == null)
            {
                this.Close();
            }
            else
            {
                Player = FormLogin.Player;
                ActualizarInterfaz();
            }
        }



        private void btbContinuar_Click(object sender, EventArgs e)
        {      
            Juego = new Form1(Player);
            Juego.ShowDialog();
            Juego.Close();
            ActualizarInterfaz();
        }

        private void btbNuevaPartida_Click(object sender, EventArgs e)
        {
            if (Player.NivelActual > 1)
            {           
                Player.Stats.Derrotas++;//Derrota por abandono
                Player.Stats.PartidasJugadas++;//Cuenta como partida jugado
            }

            Player.NivelActual = 1;
            Player.Puntuacion = 0;
            Juego = new Form1(Player);
            Juego.ShowDialog();
            Juego.Close();
            ActualizarInterfaz();
        }

        private void btbInstrucciones_Click(object sender, EventArgs e)
        {
            instrucciones.ShowDialog();
            instrucciones.Close();
        }

        private void btbEstadisticas_Click(object sender, EventArgs e)
        {

        }

        private void btbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ActualizarInterfaz()
        {
            lblUsuario.Text = "Bienvenido: " + Player.Nombre.ToString();
            if (Player.NivelActual>1)
            {
                btbContinuar.Enabled = true;
            }
            else
            {
                btbContinuar.Enabled = false;
            }
        
        }

    }
}
