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
        public GameObject[,] NivelJugable;
        public BarraJugador BarraJugador;
        public Pelota Pelota;

        private Bitmap[] BarrasImagenes;
        public Juego()
        {
            BarraJugador = new BarraJugador(new Point(350, 960), Properties.Resources.BarraPlayer, 2);
            Pelota = new Pelota(new PointF(387, 936), Properties.Resources.pelota, 1);

            BarrasImagenes = GenerarImagenes(); //Guardo en un array de Bitmaps Todas las imagenes de las barras
            Nivel Nivel = new Nivel(BarrasImagenes);//Creo el nivel
            NivelJugable = Nivel.GenerarNivel(1);//Guardo el nivel generado
            //Extraigo la fila y columna del nivel
            fila = Nivel.fila;
            columna = Nivel.columna;

            Nivel = null;//Libero el espacio de memoria que ocupa nivel, eliminando su referencia
        }


        private int fila;//Filas del nivel
        private int columna;//Columnas del nivel

        public void UpdateAll() //Actualiza todos los objetos 1 ves
        {
            this.BarraJugador.Update();

            for (int i = 0; i < fila; i++)
            {
                for (int x = 0; x < columna; x++)
                {
                    NivelJugable[i, x].Update();
                }
            }
        }

        public void DrawAll(Graphics Graph)//Dibuja Todos los objetos 1 ves
        {
            this.BarraJugador.Draw(Graph);
            this.Pelota.Draw(Graph);

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
