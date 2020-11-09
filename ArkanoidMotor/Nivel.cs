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
                        int PWP = 0;//(PowerUp Probability)
                        fila = 1;
                        columna = 1;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 2*10
                        {new GameObject(Puntos[0,0],Imagenes,1,largo,PWP)}};
                        //int PWP = 14;//(PowerUp Probability)
                        //fila = 2;
                        //columna = 10;                     
                        //Point[,] Puntos = GenerarPunto();
                        //return new GameObject[,] { //Matriz 2*10
                        //{new GameObject(Puntos[0,0],Imagenes,1,largo,PWP),new GameObject(Puntos[0,1],Imagenes,1,largo,PWP),new GameObject(Puntos[0,2],Imagenes,1,largo,PWP),new GameObject(Puntos[0,3],Imagenes,1,largo,PWP),new GameObject(Puntos[0,4],Imagenes,1,largo,PWP),new GameObject(Puntos[0,5],Imagenes,1,largo,PWP),new GameObject(Puntos[0,6],Imagenes,1,largo,PWP),new GameObject(Puntos[0,7],Imagenes,1,largo,PWP),new GameObject(Puntos[0,8],Imagenes,1,largo,PWP),new GameObject(Puntos[0,9],Imagenes,1,largo,PWP)},
                        //{new GameObject(Puntos[1,0],null,0,largo,PWP),new GameObject(Puntos[1,1],Imagenes,1,largo,PWP),new GameObject(Puntos[1,2],Imagenes,1,largo,PWP),new GameObject(Puntos[1,3],Imagenes,1,largo,PWP),new GameObject(Puntos[1,4],Imagenes,2,largo,PWP),new GameObject(Puntos[1,5],Imagenes,2,largo,PWP),new GameObject(Puntos[1,6],Imagenes,1,largo,PWP),new GameObject(Puntos[1,7],Imagenes,1,largo,PWP),new GameObject(Puntos[1,8],Imagenes,1,largo,PWP),new GameObject(Puntos[1,9],null,0,largo,PWP),} };
                    }
                case 2:
                    {
                        int PWP = 14;//(PowerUp Probability)
                        fila = 3;
                        columna = 10;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],Imagenes,1,largo,PWP),new GameObject(Puntos[0,1],Imagenes,1,largo,PWP),new GameObject(Puntos[0,2],Imagenes,1,largo,PWP),new GameObject(Puntos[0,3],Imagenes,1,largo,PWP),new GameObject(Puntos[0,4],Imagenes,1,largo,PWP),new GameObject(Puntos[0,5],Imagenes,1,largo,PWP),new GameObject(Puntos[0,6],Imagenes,1,largo,PWP),new GameObject(Puntos[0,7],Imagenes,1,largo,PWP),new GameObject(Puntos[0,8],Imagenes,1,largo,PWP),new GameObject(Puntos[0,9],Imagenes,1,largo,PWP)},
                        {new GameObject(Puntos[1,0],null,0,largo,PWP),new GameObject(Puntos[1,1],Imagenes,1,largo,PWP),new GameObject(Puntos[1,2],Imagenes,2,largo,PWP),new GameObject(Puntos[1,3],Imagenes,2,largo,PWP),new GameObject(Puntos[1,4],Imagenes,2,largo,PWP),new GameObject(Puntos[1,5],Imagenes,2,largo,PWP),new GameObject(Puntos[1,6],Imagenes,2,largo,PWP),new GameObject(Puntos[1,7],Imagenes,2,largo,PWP),new GameObject(Puntos[1,8],Imagenes,1,largo,PWP),new GameObject(Puntos[1,9],null,0,largo,PWP)},
                        {new GameObject(Puntos[2,0],null,0,largo,PWP),new GameObject(Puntos[2,1],null,0,largo,PWP),new GameObject(Puntos[2,2],Imagenes,1,largo,PWP),new GameObject(Puntos[2,3],Imagenes,2,largo,PWP),new GameObject(Puntos[2,4],Imagenes,3,largo,PWP),new GameObject(Puntos[2,5],Imagenes,3,largo,PWP),new GameObject(Puntos[2,6],Imagenes,2,largo,PWP),new GameObject(Puntos[2,7],Imagenes,1,largo,PWP),new GameObject(Puntos[2,8],null,0,largo,PWP),new GameObject(Puntos[2,9],null,0,largo,PWP)}};
                    }
                case 3:
                    {
                        int PWP = 20;//(PowerUp Probability)
                        fila = 3;
                        columna = 11;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],Imagenes,1,largo,PWP),new GameObject(Puntos[0,1],Imagenes,2,largo,PWP),new GameObject(Puntos[0,2],Imagenes,1,largo,PWP),new GameObject(Puntos[0,3],Imagenes,2,largo,PWP),new GameObject(Puntos[0,4],Imagenes,1,largo,PWP),new GameObject(Puntos[0,5],Imagenes,2,largo,PWP),new GameObject(Puntos[0,6],Imagenes,1,largo,PWP),new GameObject(Puntos[0,7],Imagenes,2,largo,PWP),new GameObject(Puntos[0,8],Imagenes,1,largo,PWP),new GameObject(Puntos[0,9],Imagenes,2,largo,PWP),new GameObject(Puntos[0,10],Imagenes,1,largo,PWP)},
                        {new GameObject(Puntos[1,0],Imagenes,2,largo,PWP),new GameObject(Puntos[1,1],Imagenes,2,largo,PWP),new GameObject(Puntos[1,2],Imagenes,2,largo,PWP),new GameObject(Puntos[1,3],Imagenes,2,largo,PWP),new GameObject(Puntos[1,4],Imagenes,2,largo,PWP),new GameObject(Puntos[1,5],Imagenes,2,largo,PWP),new GameObject(Puntos[1,6],Imagenes,2,largo,PWP),new GameObject(Puntos[1,7],Imagenes,2,largo,PWP),new GameObject(Puntos[1,8],Imagenes,2,largo,PWP),new GameObject(Puntos[1,9],Imagenes,2,largo,PWP),new GameObject(Puntos[1,10],Imagenes,2,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,1,largo,PWP),new GameObject(Puntos[2,1],Imagenes,2,largo,PWP),new GameObject(Puntos[2,2],Imagenes,2,largo,PWP),new GameObject(Puntos[2,3],Imagenes,2,largo,PWP),new GameObject(Puntos[2,4],Imagenes,3,largo,PWP),new GameObject(Puntos[2,5],Imagenes,3,largo,PWP),new GameObject(Puntos[2,6],Imagenes,3,largo,PWP),new GameObject(Puntos[2,7],Imagenes,2,largo,PWP),new GameObject(Puntos[2,8],Imagenes,2,largo,PWP),new GameObject(Puntos[2,9],Imagenes,2,largo,PWP),new GameObject(Puntos[2,10],Imagenes,1,largo,PWP)}};
                    }
                case 4:
                    {
                        int PWP = 15;//(PowerUp Probability)
                        fila = 6;
                        columna = 17;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],null,0,largo,PWP),new GameObject(Puntos[0,1],Imagenes,1,largo,PWP),new GameObject(Puntos[0,2],Imagenes,2,largo,PWP),new GameObject(Puntos[0,3],Imagenes,1,largo,PWP),new GameObject(Puntos[0,4],Imagenes,2,largo,PWP),new GameObject(Puntos[0,5],Imagenes,1,largo,PWP),new GameObject(Puntos[0,6],Imagenes,2,largo,PWP),new GameObject(Puntos[0,7],null,0,largo,PWP),new GameObject(Puntos[0,8],null,0,largo,PWP),new GameObject(Puntos[0,9],null,0,largo,PWP),new GameObject(Puntos[0,10],Imagenes,1,largo,PWP),new GameObject(Puntos[0,11],Imagenes,2,largo,PWP),new GameObject(Puntos[0,12],Imagenes,1,largo,PWP),new GameObject(Puntos[0,13],Imagenes,2,largo,PWP),new GameObject(Puntos[0,14],Imagenes,1,largo,PWP),new GameObject(Puntos[0,15],Imagenes,2,largo,PWP),new GameObject(Puntos[0,16],null,0,largo,PWP)},
                        {new GameObject(Puntos[1,0],null,0,largo,PWP),new GameObject(Puntos[1,1],Imagenes,2,largo,PWP),new GameObject(Puntos[1,2],Imagenes,1,largo,PWP),new GameObject(Puntos[1,3],Imagenes,2,largo,PWP),new GameObject(Puntos[1,4],Imagenes,1,largo,PWP),new GameObject(Puntos[1,5],Imagenes,2,largo,PWP),new GameObject(Puntos[1,6],Imagenes,1,largo,PWP),new GameObject(Puntos[1,7],null,0,largo,PWP),new GameObject(Puntos[1,8],null,0,largo,PWP),new GameObject(Puntos[1,9],null,0,largo,PWP),new GameObject(Puntos[1,10],Imagenes,2,largo,PWP),new GameObject(Puntos[1,11],Imagenes,1,largo,PWP),new GameObject(Puntos[1,12],Imagenes,2,largo,PWP),new GameObject(Puntos[1,13],Imagenes,1,largo,PWP),new GameObject(Puntos[1,14],Imagenes,2,largo,PWP),new GameObject(Puntos[1,15],Imagenes,1,largo,PWP),new GameObject(Puntos[1,16],null,0,largo,PWP)},
                        {new GameObject(Puntos[2,0],null,0,largo,PWP),new GameObject(Puntos[2,1],Imagenes,1,largo,PWP),new GameObject(Puntos[2,2],Imagenes,2,largo,PWP),new GameObject(Puntos[2,3],Imagenes,1,largo,PWP),new GameObject(Puntos[2,4],Imagenes,2,largo,PWP),new GameObject(Puntos[2,5],Imagenes,1,largo,PWP),new GameObject(Puntos[2,6],Imagenes,2,largo,PWP),new GameObject(Puntos[2,7],null,0,largo,PWP),new GameObject(Puntos[2,8],null,0,largo,PWP),new GameObject(Puntos[2,9],null,0,largo,PWP),new GameObject(Puntos[2,10],Imagenes,1,largo,PWP),new GameObject(Puntos[2,11],Imagenes,2,largo,PWP),new GameObject(Puntos[2,12],Imagenes,1,largo,PWP),new GameObject(Puntos[2,13],Imagenes,2,largo,PWP),new GameObject(Puntos[2,14],Imagenes,1,largo,PWP),new GameObject(Puntos[2,15],Imagenes,2,largo,PWP),new GameObject(Puntos[2,16],null,0,largo,PWP)},
                        {new GameObject(Puntos[3,0],null,0,largo,PWP),new GameObject(Puntos[3,1],Imagenes,2,largo,PWP),new GameObject(Puntos[3,2],Imagenes,1,largo,PWP),new GameObject(Puntos[3,3],Imagenes,2,largo,PWP),new GameObject(Puntos[3,4],Imagenes,1,largo,PWP),new GameObject(Puntos[3,5],Imagenes,2,largo,PWP),new GameObject(Puntos[3,6],Imagenes,1,largo,PWP),new GameObject(Puntos[3,7],null,0,largo,PWP),new GameObject(Puntos[3,8],null,0,largo,PWP),new GameObject(Puntos[3,9],null,0,largo,PWP),new GameObject(Puntos[3,10],Imagenes,1,largo,PWP),new GameObject(Puntos[3,11],Imagenes,1,largo,PWP),new GameObject(Puntos[3,12],Imagenes,2,largo,PWP),new GameObject(Puntos[3,13],Imagenes,1,largo,PWP),new GameObject(Puntos[3,14],Imagenes,2,largo,PWP),new GameObject(Puntos[3,15],Imagenes,1,largo,PWP),new GameObject(Puntos[3,16],null,0,largo,PWP)},
                        {new GameObject(Puntos[4,0],null,0,largo,PWP),new GameObject(Puntos[4,1],Imagenes,1,largo,PWP),new GameObject(Puntos[4,2],Imagenes,2,largo,PWP),new GameObject(Puntos[4,3],Imagenes,1,largo,PWP),new GameObject(Puntos[4,4],Imagenes,2,largo,PWP),new GameObject(Puntos[4,5],Imagenes,1,largo,PWP),new GameObject(Puntos[4,6],Imagenes,2,largo,PWP),new GameObject(Puntos[4,7],null,0,largo,PWP),new GameObject(Puntos[4,8],null,0,largo,PWP),new GameObject(Puntos[4,9],null,0,largo,PWP),new GameObject(Puntos[4,10],Imagenes,2,largo,PWP),new GameObject(Puntos[4,11],Imagenes,2,largo,PWP),new GameObject(Puntos[4,12],Imagenes,1,largo,PWP),new GameObject(Puntos[4,13],Imagenes,2,largo,PWP),new GameObject(Puntos[4,14],Imagenes,1,largo,PWP),new GameObject(Puntos[4,15],Imagenes,2,largo,PWP),new GameObject(Puntos[4,16],null,0,largo,PWP)},
                        {new GameObject(Puntos[5,0],null,0,largo,PWP),new GameObject(Puntos[5,1],Imagenes,2,largo,PWP),new GameObject(Puntos[5,2],Imagenes,1,largo,PWP),new GameObject(Puntos[5,3],Imagenes,2,largo,PWP),new GameObject(Puntos[5,4],Imagenes,1,largo,PWP),new GameObject(Puntos[5,5],Imagenes,2,largo,PWP),new GameObject(Puntos[5,6],Imagenes,1,largo,PWP),new GameObject(Puntos[5,7],null,0,largo,PWP),new GameObject(Puntos[5,8],null,0,largo,PWP),new GameObject(Puntos[5,9],null,0,largo,PWP),new GameObject(Puntos[5,10],Imagenes,1,largo,PWP),new GameObject(Puntos[5,11],Imagenes,1,largo,PWP),new GameObject(Puntos[5,12],Imagenes,2,largo,PWP),new GameObject(Puntos[5,13],Imagenes,1,largo,PWP),new GameObject(Puntos[5,14],Imagenes,2,largo,PWP),new GameObject(Puntos[5,15],Imagenes,1,largo,PWP),new GameObject(Puntos[5,16],null,0,largo,PWP)} };
                    }
                case 5:
                    {
                        int PWP = 18;//(PowerUp Probability)
                        fila = 4;
                        columna = 12;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],Imagenes,2,largo,PWP),new GameObject(Puntos[0,1],Imagenes,2,largo,PWP),new GameObject(Puntos[0,2],Imagenes,2,largo,PWP),new GameObject(Puntos[0,3],Imagenes,2,largo,PWP),new GameObject(Puntos[0,4],Imagenes,2,largo,PWP),new GameObject(Puntos[0,5],Imagenes,2,largo,PWP),new GameObject(Puntos[0,6],Imagenes,2,largo,PWP),new GameObject(Puntos[0,7],Imagenes,2,largo,PWP),new GameObject(Puntos[0,8],Imagenes,2,largo,PWP),new GameObject(Puntos[0,9],Imagenes,2,largo,PWP),new GameObject(Puntos[0,10],Imagenes,2,largo,PWP),new GameObject(Puntos[0,11],Imagenes,2,largo,PWP),},
                        {new GameObject(Puntos[1,0],Imagenes,1,largo,PWP),new GameObject(Puntos[1,1],Imagenes,1,largo,PWP),new GameObject(Puntos[1,2],Imagenes,1,largo,PWP),new GameObject(Puntos[1,3],Imagenes,1,largo,PWP),new GameObject(Puntos[1,4],Imagenes,1,largo,PWP),new GameObject(Puntos[1,5],Imagenes,1,largo,PWP),new GameObject(Puntos[1,6],Imagenes,1,largo,PWP),new GameObject(Puntos[1,7],Imagenes,1,largo,PWP),new GameObject(Puntos[1,8],Imagenes,1,largo,PWP),new GameObject(Puntos[1,9],Imagenes,1,largo,PWP),new GameObject(Puntos[1,10],Imagenes,1,largo,PWP),new GameObject(Puntos[1,11],Imagenes,1,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,3,largo,PWP),new GameObject(Puntos[2,1],Imagenes,3,largo,PWP),new GameObject(Puntos[2,2],Imagenes,3,largo,PWP),new GameObject(Puntos[2,3],Imagenes,3,largo,PWP),new GameObject(Puntos[2,4],Imagenes,3,largo,PWP),new GameObject(Puntos[2,5],Imagenes,3,largo,PWP),new GameObject(Puntos[2,6],Imagenes,3,largo,PWP),new GameObject(Puntos[2,7],Imagenes,3,largo,PWP),new GameObject(Puntos[2,8],Imagenes,3,largo,PWP),new GameObject(Puntos[2,9],Imagenes,3,largo,PWP),new GameObject(Puntos[2,10],Imagenes,3,largo,PWP),new GameObject(Puntos[2,11],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[3,0],Imagenes,1,largo,PWP),new GameObject(Puntos[3,1],Imagenes,2,largo,PWP),new GameObject(Puntos[3,2],Imagenes,3,largo,PWP),new GameObject(Puntos[3,3],Imagenes,4,largo,PWP),new GameObject(Puntos[3,4],Imagenes,5,largo,PWP),new GameObject(Puntos[3,5],Imagenes,3,largo,PWP),new GameObject(Puntos[3,6],Imagenes,3,largo,PWP),new GameObject(Puntos[3,7],Imagenes,5,largo,PWP),new GameObject(Puntos[3,8],Imagenes,4,largo,PWP),new GameObject(Puntos[3,9],Imagenes,3,largo,PWP),new GameObject(Puntos[3,10],Imagenes,2,largo,PWP),new GameObject(Puntos[3,11],Imagenes,1,largo,PWP)} };     
                    }
                case 6:
                    {
                        int PWP = 18;//(PowerUp Probability)
                        fila = 3;
                        columna = 14;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],Imagenes,3,largo,PWP),new GameObject(Puntos[0,1],Imagenes,3,largo,PWP),new GameObject(Puntos[0,2],Imagenes,3,largo,PWP),new GameObject(Puntos[0,3],Imagenes,3,largo,PWP),new GameObject(Puntos[0,4],Imagenes,3,largo,PWP),new GameObject(Puntos[0,5],Imagenes,3,largo,PWP),new GameObject(Puntos[0,6],Imagenes,3,largo,PWP),new GameObject(Puntos[0,7],Imagenes,3,largo,PWP),new GameObject(Puntos[0,8],Imagenes,3,largo,PWP),new GameObject(Puntos[0,9],Imagenes,3,largo,PWP),new GameObject(Puntos[0,10],Imagenes,3,largo,PWP),new GameObject(Puntos[0,11],Imagenes,3,largo,PWP),new GameObject(Puntos[0,12],Imagenes,3,largo,PWP),new GameObject(Puntos[0,13],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[1,0],Imagenes,4,largo,PWP),new GameObject(Puntos[1,1],Imagenes,4,largo,PWP),new GameObject(Puntos[1,2],Imagenes,4,largo,PWP),new GameObject(Puntos[1,3],Imagenes,4,largo,PWP),new GameObject(Puntos[1,4],Imagenes,4,largo,PWP),new GameObject(Puntos[1,5],Imagenes,4,largo,PWP),new GameObject(Puntos[1,6],Imagenes,4,largo,PWP),new GameObject(Puntos[1,7],Imagenes,4,largo,PWP),new GameObject(Puntos[1,8],Imagenes,4,largo,PWP),new GameObject(Puntos[1,9],Imagenes,4,largo,PWP),new GameObject(Puntos[1,10],Imagenes,4,largo,PWP),new GameObject(Puntos[1,11],Imagenes,4,largo,PWP),new GameObject(Puntos[1,12],Imagenes,4,largo,PWP),new GameObject(Puntos[1,13],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,5,largo,PWP),new GameObject(Puntos[2,1],Imagenes,5,largo,PWP),new GameObject(Puntos[2,2],Imagenes,5,largo,PWP),new GameObject(Puntos[2,3],Imagenes,5,largo,PWP),new GameObject(Puntos[2,4],Imagenes,5,largo,PWP),new GameObject(Puntos[2,5],Imagenes,5,largo,PWP),new GameObject(Puntos[2,6],Imagenes,5,largo,PWP),new GameObject(Puntos[2,7],Imagenes,5,largo,PWP),new GameObject(Puntos[2,8],Imagenes,5,largo,PWP),new GameObject(Puntos[2,9],Imagenes,5,largo,PWP),new GameObject(Puntos[2,10],Imagenes,5,largo,PWP),new GameObject(Puntos[2,11],Imagenes,5,largo,PWP),new GameObject(Puntos[2,12],Imagenes,5,largo,PWP),new GameObject(Puntos[2,13],Imagenes,5,largo,PWP)} };

                    }
                case 7:
                    {
                        int PWP = 18;//(PowerUp Probability)
                        fila = 4;
                        columna = 12;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { 
                        {new GameObject(Puntos[0,0],Imagenes,3,largo,PWP),new GameObject(Puntos[0,1],Imagenes,3,largo,PWP),new GameObject(Puntos[0,2],Imagenes,3,largo,PWP),new GameObject(Puntos[0,3],Imagenes,3,largo,PWP),new GameObject(Puntos[0,4],Imagenes,3,largo,PWP),new GameObject(Puntos[0,5],Imagenes,6,largo,PWP),new GameObject(Puntos[0,6],Imagenes,6,largo,PWP),new GameObject(Puntos[0,7],Imagenes,3,largo,PWP),new GameObject(Puntos[0,8],Imagenes,3,largo,PWP),new GameObject(Puntos[0,9],Imagenes,3,largo,PWP),new GameObject(Puntos[0,10],Imagenes,3,largo,PWP),new GameObject(Puntos[0,11],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[1,0],Imagenes,4,largo,PWP),new GameObject(Puntos[1,1],Imagenes,4,largo,PWP),new GameObject(Puntos[1,2],Imagenes,4,largo,PWP),new GameObject(Puntos[1,3],Imagenes,4,largo,PWP),new GameObject(Puntos[1,4],Imagenes,4,largo,PWP),new GameObject(Puntos[1,5],Imagenes,6,largo,PWP),new GameObject(Puntos[1,6],Imagenes,6,largo,PWP),new GameObject(Puntos[1,7],Imagenes,4,largo,PWP),new GameObject(Puntos[1,8],Imagenes,4,largo,PWP),new GameObject(Puntos[1,9],Imagenes,4,largo,PWP),new GameObject(Puntos[1,10],Imagenes,4,largo,PWP),new GameObject(Puntos[1,11],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,5,largo,PWP),new GameObject(Puntos[2,1],Imagenes,5,largo,PWP),new GameObject(Puntos[2,2],Imagenes,5,largo,PWP),new GameObject(Puntos[2,3],Imagenes,5,largo,PWP),new GameObject(Puntos[2,4],Imagenes,5,largo,PWP),new GameObject(Puntos[2,5],Imagenes,6,largo,PWP),new GameObject(Puntos[2,6],Imagenes,6,largo,PWP),new GameObject(Puntos[2,7],Imagenes,5,largo,PWP),new GameObject(Puntos[2,8],Imagenes,5,largo,PWP),new GameObject(Puntos[2,9],Imagenes,5,largo,PWP),new GameObject(Puntos[2,10],Imagenes,5,largo,PWP),new GameObject(Puntos[2,11],Imagenes,5,largo,PWP)},
                        {new GameObject(Puntos[3,0],Imagenes,2,largo,PWP),new GameObject(Puntos[3,1],Imagenes,2,largo,PWP),new GameObject(Puntos[3,2],Imagenes,2,largo,PWP),new GameObject(Puntos[3,3],Imagenes,2,largo,PWP),new GameObject(Puntos[3,4],Imagenes,2,largo,PWP),new GameObject(Puntos[3,5],Imagenes,6,largo,PWP),new GameObject(Puntos[3,6],Imagenes,6,largo,PWP),new GameObject(Puntos[3,7],Imagenes,6,largo,PWP),new GameObject(Puntos[3,8],Imagenes,2,largo,PWP),new GameObject(Puntos[3,9],Imagenes,2,largo,PWP),new GameObject(Puntos[3,10],Imagenes,2,largo,PWP),new GameObject(Puntos[3,11],Imagenes,2,largo,PWP)}};
                    }
                case 8:
                    {
                        int PWP = 20;//(PowerUp Probability)
                        fila = 6;
                        columna = 12;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] {
                        {new GameObject(Puntos[0,0],Imagenes,3,largo,PWP),new GameObject(Puntos[0,1],Imagenes,3,largo,PWP),new GameObject(Puntos[0,2],Imagenes,3,largo,PWP),new GameObject(Puntos[0,3],Imagenes,3,largo,PWP),new GameObject(Puntos[0,4],Imagenes,6,largo,PWP),new GameObject(Puntos[0,5],Imagenes,6,largo,PWP),new GameObject(Puntos[0,6],Imagenes,6,largo,PWP),new GameObject(Puntos[0,7],Imagenes,6,largo,PWP),new GameObject(Puntos[0,8],Imagenes,3,largo,PWP),new GameObject(Puntos[0,9],Imagenes,3,largo,PWP),new GameObject(Puntos[0,10],Imagenes,3,largo,PWP),new GameObject(Puntos[0,11],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[1,0],Imagenes,4,largo,PWP),new GameObject(Puntos[1,1],Imagenes,4,largo,PWP),new GameObject(Puntos[1,2],Imagenes,4,largo,PWP),new GameObject(Puntos[1,3],Imagenes,4,largo,PWP),new GameObject(Puntos[1,4],Imagenes,4,largo,PWP),new GameObject(Puntos[1,5],Imagenes,6,largo,PWP),new GameObject(Puntos[1,6],Imagenes,6,largo,PWP),new GameObject(Puntos[1,7],Imagenes,4,largo,PWP),new GameObject(Puntos[1,8],Imagenes,4,largo,PWP),new GameObject(Puntos[1,9],Imagenes,4,largo,PWP),new GameObject(Puntos[1,10],Imagenes,4,largo,PWP),new GameObject(Puntos[1,11],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,5,largo,PWP),new GameObject(Puntos[2,1],Imagenes,5,largo,PWP),new GameObject(Puntos[2,2],Imagenes,5,largo,PWP),new GameObject(Puntos[2,3],Imagenes,5,largo,PWP),new GameObject(Puntos[2,4],Imagenes,5,largo,PWP),new GameObject(Puntos[2,5],Imagenes,6,largo,PWP),new GameObject(Puntos[2,6],Imagenes,6,largo,PWP),new GameObject(Puntos[2,7],Imagenes,5,largo,PWP),new GameObject(Puntos[2,8],Imagenes,5,largo,PWP),new GameObject(Puntos[2,9],Imagenes,5,largo,PWP),new GameObject(Puntos[2,10],Imagenes,5,largo,PWP),new GameObject(Puntos[2,11],Imagenes,5,largo,PWP)},
                        {new GameObject(Puntos[3,0],Imagenes,5,largo,PWP),new GameObject(Puntos[3,1],Imagenes,5,largo,PWP),new GameObject(Puntos[3,2],Imagenes,5,largo,PWP),new GameObject(Puntos[3,3],Imagenes,5,largo,PWP),new GameObject(Puntos[3,4],Imagenes,5,largo,PWP),new GameObject(Puntos[3,5],Imagenes,6,largo,PWP),new GameObject(Puntos[3,6],Imagenes,6,largo,PWP),new GameObject(Puntos[3,7],Imagenes,5,largo,PWP),new GameObject(Puntos[3,8],Imagenes,5,largo,PWP),new GameObject(Puntos[3,9],Imagenes,5,largo,PWP),new GameObject(Puntos[3,10],Imagenes,5,largo,PWP),new GameObject(Puntos[3,11],Imagenes,5,largo,PWP)},
                        {new GameObject(Puntos[4,0],Imagenes,4,largo,PWP),new GameObject(Puntos[4,1],Imagenes,4,largo,PWP),new GameObject(Puntos[4,2],Imagenes,4,largo,PWP),new GameObject(Puntos[4,3],Imagenes,4,largo,PWP),new GameObject(Puntos[4,4],Imagenes,4,largo,PWP),new GameObject(Puntos[4,5],Imagenes,6,largo,PWP),new GameObject(Puntos[4,6],Imagenes,6,largo,PWP),new GameObject(Puntos[4,7],Imagenes,4,largo,PWP),new GameObject(Puntos[4,8],Imagenes,4,largo,PWP),new GameObject(Puntos[4,9],Imagenes,4,largo,PWP),new GameObject(Puntos[4,10],Imagenes,4,largo,PWP),new GameObject(Puntos[4,11],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[5,0],Imagenes,3,largo,PWP),new GameObject(Puntos[5,1],Imagenes,3,largo,PWP),new GameObject(Puntos[5,2],Imagenes,3,largo,PWP),new GameObject(Puntos[5,3],Imagenes,3,largo,PWP),new GameObject(Puntos[5,4],Imagenes,3,largo,PWP),new GameObject(Puntos[5,5],Imagenes,6,largo,PWP),new GameObject(Puntos[5,6],Imagenes,6,largo,PWP),new GameObject(Puntos[5,7],Imagenes,3,largo,PWP),new GameObject(Puntos[5,8],Imagenes,3,largo,PWP),new GameObject(Puntos[5,9],Imagenes,3,largo,PWP),new GameObject(Puntos[5,10],Imagenes,3,largo,PWP),new GameObject(Puntos[5,11],Imagenes,3,largo,PWP)}};
                    }

                case 9:
                    {
                        int PWP = 20;//(PowerUp Probability)
                        fila = 6;
                        columna = 17;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],Imagenes,5,largo,PWP),new GameObject(Puntos[0,1],Imagenes,4,largo,PWP),new GameObject(Puntos[0,2],Imagenes,5,largo,PWP),new GameObject(Puntos[0,3],Imagenes,4,largo,PWP),new GameObject(Puntos[0,4],Imagenes,5,largo,PWP),new GameObject(Puntos[0,5],Imagenes,4,largo,PWP),new GameObject(Puntos[0,6],Imagenes,5,largo,PWP),new GameObject(Puntos[0,7],null,0,largo,PWP),new GameObject(Puntos[0,8],null,0,largo,PWP),new GameObject(Puntos[0,9],null,0,largo,PWP),new GameObject(Puntos[0,10],Imagenes,5,largo,PWP),new GameObject(Puntos[0,11],Imagenes,4,largo,PWP),new GameObject(Puntos[0,12],Imagenes,5,largo,PWP),new GameObject(Puntos[0,13],Imagenes,4,largo,PWP),new GameObject(Puntos[0,14],Imagenes,5,largo,PWP),new GameObject(Puntos[0,15],Imagenes,4,largo,PWP),new GameObject(Puntos[0,16],Imagenes,5,largo,PWP)},
                        {new GameObject(Puntos[1,0],Imagenes,3,largo,PWP),new GameObject(Puntos[1,1],Imagenes,3,largo,PWP),new GameObject(Puntos[1,2],Imagenes,3,largo,PWP),new GameObject(Puntos[1,3],Imagenes,3,largo,PWP),new GameObject(Puntos[1,4],Imagenes,3,largo,PWP),new GameObject(Puntos[1,5],Imagenes,3,largo,PWP),new GameObject(Puntos[1,6],Imagenes,3,largo,PWP),new GameObject(Puntos[1,7],null,0,largo,PWP),new GameObject(Puntos[1,8],null,0,largo,PWP),new GameObject(Puntos[1,9],null,0,largo,PWP),new GameObject(Puntos[1,10],Imagenes,2,largo,PWP),new GameObject(Puntos[1,11],Imagenes,3,largo,PWP),new GameObject(Puntos[1,12],Imagenes,3,largo,PWP),new GameObject(Puntos[1,13],Imagenes,3,largo,PWP),new GameObject(Puntos[1,14],Imagenes,3,largo,PWP),new GameObject(Puntos[1,15],Imagenes,3,largo,PWP),new GameObject(Puntos[1,16],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,3,largo,PWP),new GameObject(Puntos[2,1],Imagenes,3,largo,PWP),new GameObject(Puntos[2,2],Imagenes,3,largo,PWP),new GameObject(Puntos[2,3],Imagenes,3,largo,PWP),new GameObject(Puntos[2,4],Imagenes,3,largo,PWP),new GameObject(Puntos[2,5],Imagenes,3,largo,PWP),new GameObject(Puntos[2,6],Imagenes,3,largo,PWP),new GameObject(Puntos[2,7],null,0,largo,PWP),new GameObject(Puntos[2,8],null,0,largo,PWP),new GameObject(Puntos[2,9],null,0,largo,PWP),new GameObject(Puntos[2,10],Imagenes,3,largo,PWP),new GameObject(Puntos[2,11],Imagenes,3,largo,PWP),new GameObject(Puntos[2,12],Imagenes,3,largo,PWP),new GameObject(Puntos[2,13],Imagenes,3,largo,PWP),new GameObject(Puntos[2,14],Imagenes,3,largo,PWP),new GameObject(Puntos[2,15],Imagenes,3,largo,PWP),new GameObject(Puntos[2,16],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[3,0],Imagenes,3,largo,PWP),new GameObject(Puntos[3,1],Imagenes,3,largo,PWP),new GameObject(Puntos[3,2],Imagenes,3,largo,PWP),new GameObject(Puntos[3,3],Imagenes,3,largo,PWP),new GameObject(Puntos[3,4],Imagenes,3,largo,PWP),new GameObject(Puntos[3,5],Imagenes,3,largo,PWP),new GameObject(Puntos[3,6],Imagenes,3,largo,PWP),new GameObject(Puntos[3,7],null,0,largo,PWP),new GameObject(Puntos[3,8],Imagenes,6,largo,PWP),new GameObject(Puntos[3,9],null,0,largo,PWP),new GameObject(Puntos[3,10],Imagenes,3,largo,PWP),new GameObject(Puntos[3,11],Imagenes,3,largo,PWP),new GameObject(Puntos[3,12],Imagenes,3,largo,PWP),new GameObject(Puntos[3,13],Imagenes,3,largo,PWP),new GameObject(Puntos[3,14],Imagenes,3,largo,PWP),new GameObject(Puntos[3,15],Imagenes,3,largo,PWP),new GameObject(Puntos[3,16],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[4,0],Imagenes,3,largo,PWP),new GameObject(Puntos[4,1],Imagenes,3,largo,PWP),new GameObject(Puntos[4,2],Imagenes,3,largo,PWP),new GameObject(Puntos[4,3],Imagenes,3,largo,PWP),new GameObject(Puntos[4,4],Imagenes,3,largo,PWP),new GameObject(Puntos[4,5],Imagenes,3,largo,PWP),new GameObject(Puntos[4,6],Imagenes,3,largo,PWP),new GameObject(Puntos[4,7],null,0,largo,PWP),new GameObject(Puntos[4,8],Imagenes,6,largo,PWP),new GameObject(Puntos[4,9],null,0,largo,PWP),new GameObject(Puntos[4,10],Imagenes,3,largo,PWP),new GameObject(Puntos[4,11],Imagenes,3,largo,PWP),new GameObject(Puntos[4,12],Imagenes,3,largo,PWP),new GameObject(Puntos[4,13],Imagenes,3,largo,PWP),new GameObject(Puntos[4,14],Imagenes,3,largo,PWP),new GameObject(Puntos[4,15],Imagenes,3,largo,PWP),new GameObject(Puntos[4,16],Imagenes,3,largo,PWP)},
                        {new GameObject(Puntos[5,0],Imagenes,6,largo,PWP),new GameObject(Puntos[5,1],Imagenes,4,largo,PWP),new GameObject(Puntos[5,2],Imagenes,5,largo,PWP),new GameObject(Puntos[5,3],Imagenes,4,largo,PWP),new GameObject(Puntos[5,4],Imagenes,5,largo,PWP),new GameObject(Puntos[5,5],Imagenes,4,largo,PWP),new GameObject(Puntos[5,6],Imagenes,5,largo,PWP),new GameObject(Puntos[5,7],Imagenes,6,largo,PWP),new GameObject(Puntos[5,8],Imagenes,6,largo,PWP),new GameObject(Puntos[5,9],Imagenes,6,largo,PWP),new GameObject(Puntos[5,10],Imagenes,5,largo,PWP),new GameObject(Puntos[5,11],Imagenes,4,largo,PWP),new GameObject(Puntos[5,12],Imagenes,5,largo,PWP),new GameObject(Puntos[5,13],Imagenes,4,largo,PWP),new GameObject(Puntos[5,14],Imagenes,5,largo,PWP),new GameObject(Puntos[5,15],Imagenes,4,largo,PWP),new GameObject(Puntos[5,16],Imagenes,6,largo,PWP)} };

                    }
                case 10:
                    {
                        int PWP = 18;//(PowerUp Probability)
                        fila = 7;
                        columna = 13;
                        Point[,] Puntos = GenerarPunto();
                        return new GameObject[,] { //Matriz 3*10
                        {new GameObject(Puntos[0,0],Imagenes,4,largo,PWP),new GameObject(Puntos[0,1],Imagenes,4,largo,PWP),new GameObject(Puntos[0,2],Imagenes,4,largo,PWP),new GameObject(Puntos[0,3],Imagenes,4,largo,PWP),new GameObject(Puntos[0,4],Imagenes,4,largo,PWP),new GameObject(Puntos[0,5],Imagenes,4,largo,PWP),new GameObject(Puntos[0,6],Imagenes,4,largo,PWP),new GameObject(Puntos[0,7],Imagenes,4,largo,PWP),new GameObject(Puntos[0,8],Imagenes,4,largo,PWP),new GameObject(Puntos[0,9],Imagenes,4,largo,PWP),new GameObject(Puntos[0,10],Imagenes,4,largo,PWP),new GameObject(Puntos[0,11],Imagenes,4,largo,PWP),new GameObject(Puntos[0,12],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[1,0],Imagenes,4,largo,PWP),new GameObject(Puntos[1,1],Imagenes,4,largo,PWP),new GameObject(Puntos[1,2],Imagenes,4,largo,PWP),new GameObject(Puntos[1,3],Imagenes,4,largo,PWP),new GameObject(Puntos[1,4],Imagenes,4,largo,PWP),new GameObject(Puntos[1,5],Imagenes,4,largo,PWP),new GameObject(Puntos[1,6],Imagenes,4,largo,PWP),new GameObject(Puntos[1,7],Imagenes,4,largo,PWP),new GameObject(Puntos[1,8],Imagenes,4,largo,PWP),new GameObject(Puntos[1,9],Imagenes,4,largo,PWP),new GameObject(Puntos[1,10],Imagenes,4,largo,PWP),new GameObject(Puntos[1,11],Imagenes,4,largo,PWP),new GameObject(Puntos[1,12],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[2,0],Imagenes,6,largo,PWP),new GameObject(Puntos[2,1],Imagenes,6,largo,PWP),new GameObject(Puntos[2,2],Imagenes,5,largo,PWP),new GameObject(Puntos[2,3],Imagenes,5,largo,PWP),new GameObject(Puntos[2,4],Imagenes,5,largo,PWP),new GameObject(Puntos[2,5],Imagenes,5,largo,PWP),new GameObject(Puntos[2,6],Imagenes,5,largo,PWP),new GameObject(Puntos[2,7],Imagenes,5,largo,PWP),new GameObject(Puntos[2,8],Imagenes,5,largo,PWP),new GameObject(Puntos[2,9],Imagenes,5,largo,PWP),new GameObject(Puntos[2,10],Imagenes,5,largo,PWP),new GameObject(Puntos[2,11],Imagenes,6,largo,PWP),new GameObject(Puntos[2,12],Imagenes,6,largo,PWP)},
                        {new GameObject(Puntos[3,0],Imagenes,5,largo,PWP),new GameObject(Puntos[3,1],Imagenes,5,largo,PWP),new GameObject(Puntos[3,2],Imagenes,5,largo,PWP),new GameObject(Puntos[3,3],Imagenes,5,largo,PWP),new GameObject(Puntos[3,4],Imagenes,5,largo,PWP),new GameObject(Puntos[3,5],Imagenes,5,largo,PWP),new GameObject(Puntos[3,6],Imagenes,5,largo,PWP),new GameObject(Puntos[3,7],Imagenes,5,largo,PWP),new GameObject(Puntos[3,8],Imagenes,5,largo,PWP),new GameObject(Puntos[3,9],Imagenes,5,largo,PWP),new GameObject(Puntos[3,10],Imagenes,5,largo,PWP),new GameObject(Puntos[3,11],Imagenes,5,largo,PWP),new GameObject(Puntos[3,12],Imagenes,5,largo,PWP)},
                        {new GameObject(Puntos[4,0],Imagenes,4,largo,PWP),new GameObject(Puntos[4,1],Imagenes,4,largo,PWP),new GameObject(Puntos[4,2],Imagenes,4,largo,PWP),new GameObject(Puntos[4,3],Imagenes,4,largo,PWP),new GameObject(Puntos[4,4],Imagenes,4,largo,PWP),new GameObject(Puntos[4,5],Imagenes,4,largo,PWP),new GameObject(Puntos[4,6],Imagenes,4,largo,PWP),new GameObject(Puntos[4,7],Imagenes,4,largo,PWP),new GameObject(Puntos[4,8],Imagenes,4,largo,PWP),new GameObject(Puntos[4,9],Imagenes,4,largo,PWP),new GameObject(Puntos[4,10],Imagenes,4,largo,PWP),new GameObject(Puntos[4,11],Imagenes,4,largo,PWP),new GameObject(Puntos[4,12],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[5,0],Imagenes,4,largo,PWP),new GameObject(Puntos[5,1],Imagenes,4,largo,PWP),new GameObject(Puntos[5,2],Imagenes,4,largo,PWP),new GameObject(Puntos[5,3],Imagenes,4,largo,PWP),new GameObject(Puntos[5,4],Imagenes,4,largo,PWP),new GameObject(Puntos[5,5],Imagenes,4,largo,PWP),new GameObject(Puntos[5,6],Imagenes,4,largo,PWP),new GameObject(Puntos[5,7],Imagenes,4,largo,PWP),new GameObject(Puntos[5,8],Imagenes,4,largo,PWP),new GameObject(Puntos[5,9],Imagenes,4,largo,PWP),new GameObject(Puntos[5,10],Imagenes,4,largo,PWP),new GameObject(Puntos[5,11],Imagenes,4,largo,PWP),new GameObject(Puntos[5,12],Imagenes,4,largo,PWP)},
                        {new GameObject(Puntos[6,0],Imagenes,6,largo,PWP),new GameObject(Puntos[6,1],Imagenes,6,largo,PWP),new GameObject(Puntos[6,2],Imagenes,6,largo,PWP),new GameObject(Puntos[6,3],Imagenes,6,largo,PWP),new GameObject(Puntos[6,4],Imagenes,6,largo,PWP),new GameObject(Puntos[6,5],Imagenes,1,largo,PWP),new GameObject(Puntos[6,6],Imagenes,1,largo,PWP),new GameObject(Puntos[6,7],Imagenes,1,largo,PWP),new GameObject(Puntos[6,8],Imagenes,6,largo,PWP),new GameObject(Puntos[6,9],Imagenes,6,largo,PWP),new GameObject(Puntos[6,10],Imagenes,6,largo,PWP),new GameObject(Puntos[6,11],Imagenes,6,largo,PWP),new GameObject(Puntos[6,12],Imagenes,6,largo,PWP)}};


                    }


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
