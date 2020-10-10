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

            fila = 2;
            columna = 10;
            PointF[,] Puntos = GenerarPunto();
            return new GameObject[,] { //Matriz 2*10
                        {new GameObject(Puntos[0,0],ImgB[1],1),new GameObject(Puntos[0,1],ImgB[1],1),new GameObject(Puntos[0,2],ImgB[1],1),new GameObject(Puntos[0,3],ImgB[1],1),new GameObject(Puntos[0,4],ImgB[1],1),new GameObject(Puntos[0,5],ImgB[1],1),new GameObject(Puntos[0,6],ImgB[1],1),new GameObject(Puntos[0,7],ImgB[1],1),new GameObject(Puntos[0,8],ImgB[1],1),new GameObject(Puntos[0,9],ImgB[1],1)},
                        {new GameObject(Puntos[0,0],null,0),new GameObject(Puntos[1,1],ImgB[1],1),new GameObject(Puntos[1,2],ImgB[1],1),new GameObject(Puntos[1,3],ImgB[1],1),new GameObject(Puntos[1,4],ImgB[2],2),new GameObject(Puntos[1,5],ImgB[2],2),new GameObject(Puntos[1,6],ImgB[1],1),new GameObject(Puntos[1,7],ImgB[1],1),new GameObject(Puntos[1,8],ImgB[1],1),new GameObject(Puntos[1,9],null,0),} };
            //int Slvl = lvl;
            //switch (Slvl)
            //{
            //    case '1': 
            //        {
                     
            //        }

            //    default:
            //        break;
            //}
            //return null;
        }


       

        private int ancho = 750;
 
        private PointF[,] GenerarPunto()
        {
            int PosFila = -100;
            float PosX = ancho / columna;
            float posXActual = 0;

            PointF[,] Puntos = new PointF[fila, columna];
            
            for (int i = 0; i < fila; i++)
            {
                PosFila += -50;
                for (int x = 0; x < columna; x++)
                {
                    posXActual += -PosX;
                    Puntos[x, i] = new PointF(posXActual, PosFila);
                }
            }
            return Puntos;
        }

     
        //for (int fila = 0; fila < Nivel.GetLength(0); fila++)
        //{
        //    for (int columna = 0; columna < Nivel.GetLength(1); columna++)
        //    {

        //    }
        //}
    }
}
