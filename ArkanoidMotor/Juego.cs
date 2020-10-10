using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace ArkanoidMotor
{
    public class Juego
    {
        private Bitmap[] BarrasImagenes;


        public Nivel Nivel;
        public GameObject[,] NivelJugable;
        private int fila;
        private int columna;

        public Juego()
        {
            BarrasImagenes = GenerarImagenes();
            Nivel = new Nivel(BarrasImagenes);
            NivelJugable = Nivel.GenerarNivel(1);
            fila = Nivel.fila;
            columna = Nivel.columna;

            Nivel = null;
        
        }

        public void UpdateAll()
        {


        }

        public void DrawAll(Graphics Graph)
        {
            for (int i = 0; i < fila; i++)
            {
                for (int x = 0; x < columna; x++)
                {
                    NivelJugable[i, x].Draw(Graph);
                }
            }
        }


        private Bitmap[] GenerarImagenes()
        {
            Bitmap[] Barras = new Bitmap[7];
            Barras[0] = null;
            Barras[1] = new Bitmap(Properties.Resources.Barra1);
            Barras[2] = new Bitmap(Properties.Resources.Barra2);
            Barras[3] = new Bitmap(Properties.Resources.Barra3);
            Barras[4] = new Bitmap(Properties.Resources.Barra4);
            Barras[5] = new Bitmap(Properties.Resources.Barra5);
            Barras[6] = new Bitmap(Properties.Resources.Barra6);
            return Barras;
        }
     



    }
}
