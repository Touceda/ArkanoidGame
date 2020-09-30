using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidMotor
{
    public class Nivel
    {
        public GameObject[,] NivelUno = new GameObject[,] { //Matriz 2*10
        {new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(1)},
        {new GameObject(0),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(2),new GameObject(2),new GameObject(1),new GameObject(1),new GameObject(1),new GameObject(0),} };
            
        public Nivel()
        {
           
        
        }



    }
}
