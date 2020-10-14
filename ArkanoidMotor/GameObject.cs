using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class GameObject
    {
        private int vidas;
        public int Vidas { get { return vidas; } set { vidas = value; } }

        private Bitmap miImagen;
        public Bitmap MiImagen { get { return miImagen; } set { miImagen = value; } }

        private PointF miCoordenada;
        public PointF MiCoordenada { get { return miCoordenada; } set { miCoordenada = value; }}

        private SizeF miTamaño;
        public SizeF MiTamaño { get { return miTamaño; } set { miTamaño = value; }}


        public GameObject(PointF point, Bitmap imagen = null, int vida = 0, float tamañoLargo = 0)
        {
            miCoordenada = point;
            this.MiImagen = imagen;
            this.vidas = vida;
            this.miTamaño = new SizeF(tamañoLargo,32);
        }

        public virtual void Update()
        { 
        
        
        }

        public virtual void Draw(Graphics Graph)
        {
            if (MiImagen != null)
            {
                Graph.DrawImage(MiImagen, new RectangleF(MiCoordenada, MiTamaño));//Le puedo pasar el wh y he para ajustar el tamaño (Revisar para futuros niveles)
            }    
        }




    }
}
