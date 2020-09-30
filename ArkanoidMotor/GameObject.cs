using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidMotor
{
    public class GameObject
    {
  

        private int vidas;

        public int Vidas { get { return vidas; } set { vidas = value; } }


        public GameObject(int vidas = 0)
        {
            Vidas = vidas;
        }


        public void Update()
        { 
        
        
        }

        public void Draw()
        { 
        
        }




    }
}
