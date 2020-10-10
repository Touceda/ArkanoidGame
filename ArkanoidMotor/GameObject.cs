using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidMotor
{
    public class GameObject
    {
        private Bitmap MiImagen;
        private PointF MiCoordenada;
        

        private int vidas;
        public int Vidas { get { return vidas; } set { vidas = value; } }


        public GameObject(PointF point, Bitmap imagen = null, int vidas = 0)
        {
            MiCoordenada = point;

            this.MiImagen = imagen;
            Vidas = vidas;
            
        }

        public void Update()
        { 
        
        
        }
        public void Draw(Graphics Graph)
        {
            Graph.DrawImage(MiImagen, MiCoordenada);
        }




    }
}
