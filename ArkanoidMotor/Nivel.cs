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
        private Bitmap[] ImgB;

        public Nivel(Bitmap[] imagenes)
        {
            this.ImgB = imagenes;
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
                        PointF[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 2*10
                        {new GameObject(Puntos[0,0],ImgB[1],1,largo),new GameObject(Puntos[0,1],ImgB[1],1,largo),new GameObject(Puntos[0,2],ImgB[1],1,largo),new GameObject(Puntos[0,3],ImgB[1],1,largo),new GameObject(Puntos[0,4],ImgB[1],1,largo),new GameObject(Puntos[0,5],ImgB[1],1,largo),new GameObject(Puntos[0,6],ImgB[1],1,largo),new GameObject(Puntos[0,7],ImgB[1],1,largo),new GameObject(Puntos[0,8],ImgB[1],1,largo),new GameObject(Puntos[0,9],ImgB[1],1,largo)},
                        {new GameObject(Puntos[0,0],null,0,largo),new GameObject(Puntos[1,1],ImgB[1],1,largo),new GameObject(Puntos[1,2],ImgB[1],1,largo),new GameObject(Puntos[1,3],ImgB[1],1,largo),new GameObject(Puntos[1,4],ImgB[2],2,largo),new GameObject(Puntos[1,5],ImgB[2],2,largo),new GameObject(Puntos[1,6],ImgB[1],1,largo),new GameObject(Puntos[1,7],ImgB[1],1,largo),new GameObject(Puntos[1,8],ImgB[1],1,largo),new GameObject(Puntos[1,9],null,0,largo),} };
                    }

                default:
                    break;
            }
            return null;
        }


       

        private int ancho = 760;//ancho del mundo descontando los bordes
        private float largo = 0;//El largo que va a tener las barras
        private PointF[,] GenerarPunto() //En este metodo genero las coordenadas donde se encuentran las barras
        {
            largo = ancho / columna;//El largo que van a tener las barras
            
            int CoorY = 0; //Coordenada Y
            float distX = 0;//Distancia entre una barra y la otra
            float CoorX = 0;//Coordenada X

            PointF[,] Puntos = new PointF[fila, columna];//Aca almaceno las coordenadas que va a tener las barras



            for (int x = 0; x < fila; x++)
            {
                CoorY += 45;//arranca en 45 porque es una altura normal
                distX = 20;//Arranca eb 20, para no comer el borde del mapa
                for (int i = 0; i < columna; i++)
                {
                    CoorX += distX;
                    Puntos[x, i] = new PointF(CoorX, CoorY);
                    distX = largo; //Saco a que distancia va a estar una barra de la otra
                }
                CoorX = 0;
            }

            largo = largo - columna;//Ajusto el largo de la barra para que esten separadas

            return Puntos;
        }
    }
}
