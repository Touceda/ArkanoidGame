using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class Nivel
    {
        private Bitmap[] Imagenes;

        public Nivel(Bitmap[] imagenes)
        {
            this.Imagenes = imagenes;
        }

        public int fila;
        public int columna;

        public GameObject[,] GenerarNivel(int lvl)
        {
            int Slvl = lvl;
            switch (Slvl)
            {
                case 1:
                    {
                        fila = 2;
                        columna = 10;                     
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 2*10
                        {new GameObject(Puntos[0,0],Imagenes,1,largo),new GameObject(Puntos[0,1],Imagenes,1,largo),new GameObject(Puntos[0,2],Imagenes,1,largo),new GameObject(Puntos[0,3],Imagenes,1,largo),new GameObject(Puntos[0,4],Imagenes,1,largo),new GameObject(Puntos[0,5],Imagenes,1,largo),new GameObject(Puntos[0,6],Imagenes,1,largo),new GameObject(Puntos[0,7],Imagenes,1,largo),new GameObject(Puntos[0,8],Imagenes,1,largo),new GameObject(Puntos[0,9],Imagenes,1,largo)},
                        {new GameObject(Puntos[1,0],null,0,largo),new GameObject(Puntos[1,1],Imagenes,1,largo),new GameObject(Puntos[1,2],Imagenes,1,largo),new GameObject(Puntos[1,3],Imagenes,1,largo),new GameObject(Puntos[1,4],Imagenes,2,largo),new GameObject(Puntos[1,5],Imagenes,2,largo),new GameObject(Puntos[1,6],Imagenes,1,largo),new GameObject(Puntos[1,7],Imagenes,1,largo),new GameObject(Puntos[1,8],Imagenes,1,largo),new GameObject(Puntos[1,9],null,0,largo),} };
                    }
                //case 2:
                //    {
                //        fila = 3;
                //        columna = 15;
                //        Point[,] Puntos = GenerarPunto();
                //        return new GameObject[,] { //Matriz 2*10
                //        {new GameObject(Puntos[0,0],I[1],1,largo),new GameObject(Puntos[0,1],I[1],1,largo),new GameObject(Puntos[0,2],I[1],1,largo),new GameObject(Puntos[0,3],I[1],1,largo),new GameObject(Puntos[0,4],I[1],1,largo),new GameObject(Puntos[0,5],I[1],1,largo),new GameObject(Puntos[0,6],I[1],1,largo),new GameObject(Puntos[0,7],I[1],1,largo),new GameObject(Puntos[0,8],I[1],1,largo),new GameObject(Puntos[0,9],I[1],1,largo),new GameObject(Puntos[0,10],I[1],1,largo),new GameObject(Puntos[0,11],I[1],1,largo),new GameObject(Puntos[0,12],I[1],1,largo),new GameObject(Puntos[0,13],I[1],1,largo),new GameObject(Puntos[0,14],I[1],1,largo)},
                //        {new GameObject(Puntos[1,0],null,0,largo),new GameObject(Puntos[1,1],I[1],1,largo),new GameObject(Puntos[1,2],I[1],1,largo),new GameObject(Puntos[1,3],I[1],1,largo),new GameObject(Puntos[1,4],I[2],2,largo),new GameObject(Puntos[1,5],I[2],2,largo),new GameObject(Puntos[1,6],I[1],1,largo),new GameObject(Puntos[1,7],I[1],1,largo),new GameObject(Puntos[1,8],I[1],1,largo),new GameObject(Puntos[1,9],null,0,largo),new GameObject(Puntos[1,10],I[1],1,largo),new GameObject(Puntos[1,11],I[1],1,largo),new GameObject(Puntos[1,12],I[1],1,largo),new GameObject(Puntos[1,13],I[1],1,largo),new GameObject(Puntos[1,14],I[1],1,largo)},
                //        {new GameObject(Puntos[2,0],I[1],1,largo),new GameObject(Puntos[2,1],I[1],1,largo),new GameObject(Puntos[2,2],I[1],1,largo),new GameObject(Puntos[2,3],I[1],1,largo),new GameObject(Puntos[2,4],I[1],1,largo),new GameObject(Puntos[2,5],I[1],1,largo),new GameObject(Puntos[2,6],I[1],1,largo),new GameObject(Puntos[2,7],I[1],1,largo),new GameObject(Puntos[2,8],I[1],1,largo),new GameObject(Puntos[2,9],I[1],1,largo),new GameObject(Puntos[2,10],I[1],1,largo),new GameObject(Puntos[2,11],I[1],1,largo),new GameObject(Puntos[2,12],I[1],1,largo),new GameObject(Puntos[2,13],I[1],1,largo),new GameObject(Puntos[2,14],I[1],1,largo) } };
                //    }
                default:
                    break;
            }
            return null;
        }


       

        private int ancho = 760;//ancho del mundo descontando los bordes
        private int largo = 0;//El largo que va a tener las barras
        private Point[,] GenerarPunto() //En este metodo genero las coordenadas donde se encuentran las barras
        {
            largo = ancho / columna;//El largo que van a tener las barras
            
            int CoorY = 0; //Coordenada Y
            int distX = 0;//Distancia entre una barra y la otra
            int CoorX = 0;//Coordenada X

            Point[,] Puntos = new Point[fila, columna];//Aca almaceno las coordenadas que va a tener las barras



            for (int x = 0; x < fila; x++)
            {
                CoorY += 45;//arranca en 45 porque es una altura normal
                distX = 20;//Arranca eb 20, para no comer el borde del mapa
                for (int i = 0; i < columna; i++)
                {
                    CoorX += distX;
                    Puntos[x, i] = new Point(CoorX, CoorY);
                    distX = largo; //Saco a que distancia va a estar una barra de la otra
                }
                CoorX = 0;
            }

            largo = largo - columna;//Ajusto el largo de la barra para que esten separadas
            //CalcularPuntosDeColicion(largo,Puntos,fila,columna);
            return Puntos;
        }

        private void CalcularPuntosDeColicion(int largo, int fila, int columna)
        {
            int LargoAuxiliar = largo;
            List<int> PtosArribaAbajo = new List<int>();
            //List<int> PtosAbajo = new List<int>();
            List<int> PtosDerechaIzquierda = new List<int>();

            for (int i = 0; i <= largo; i++)
            {
                PtosArribaAbajo.Add(20 + i); //Calcula el eje x de los
            }

        }
    }
}
