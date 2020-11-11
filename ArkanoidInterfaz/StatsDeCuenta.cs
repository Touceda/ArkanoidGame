using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ArkanoidInterfaz
{
    public partial class StatsDeCuenta : Form
    {
        private DataTable Stats;
        private DataTable LogsDeJugador;
        private string Usuario;
        public StatsDeCuenta(DataTable Stats, DataTable logsDeJugador, string usuario)
        {
            this.Stats = Stats;
            this.LogsDeJugador = logsDeJugador;
            this.Usuario = usuario;
            InitializeComponent();
        }

        private void StatsDeCuenta_Load(object sender, EventArgs e)
        {
            string usuario = "";
            int partidasJugadas = 0;
            int nivelesCompletados = 0;
            int nivelesPerdidos = 0;
            int victorias = 0;
            int derrotas = 0;
            int puntuacionMasAlta = 0;
            string tiempoJugado = "";

            foreach (DataRow fila in Stats.Rows)
            {
                usuario = fila[0].ToString();
                if (this.Usuario == usuario)
                {
                    partidasJugadas = int.Parse(fila[1].ToString());
                    nivelesCompletados = int.Parse(fila[2].ToString());
                    nivelesPerdidos = int.Parse(fila[3].ToString());
                    victorias = int.Parse(fila[4].ToString());
                    derrotas = int.Parse(fila[5].ToString());
                    puntuacionMasAlta = int.Parse(fila[6].ToString());
                    tiempoJugado = fila[7].ToString();
                    break;
                }               
            }


            lblusuario.Text = "Stats de " + usuario;
            lbl1.Text = "Partidas Jugadas = " + partidasJugadas.ToString();
            lbl2.Text = "Niveles Completados = " + nivelesCompletados.ToString();
            lbl3.Text = "Niveles Perdidos = " + nivelesPerdidos.ToString();
            lbl4.Text = "Cantidad de Victorias = " + victorias.ToString();
            lbl5.Text = "Cantidad de Derrotas = " + derrotas.ToString();
            lbl6.Text = "Max Puntuacion = " + puntuacionMasAlta.ToString();
            lbl7.Text = "Tiempo De Juego = " + tiempoJugado.ToString() + " (D,H,Min,Sec)";

            float porcentaje;
            if (partidasJugadas == 0)
            {
                porcentaje = 0;
            }
            else
            {
                porcentaje = (100 * victorias) / partidasJugadas;
            }
            

            lbl8.Text = "Promedio De Victorias " + porcentaje.ToString() + "%";
        


        }

        private void btbSiguiente_Click(object sender, EventArgs e)
        {
            StatsDeCuentas2 stc2 = new StatsDeCuentas2(LogsDeJugador);
            stc2.ShowDialog();
            stc2.Close();
        }
    }
}
