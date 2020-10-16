using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidMotor
{
    public class Pelota : GameObject
    {
        public Pelota(PointF point, Bitmap imagen = null, int vida = 0)
       :base(point, imagen, vida)
        {
            this.MiCoordenada = point;
            this.MiImagen = imagen;
            this.Vidas = vida;
            this.MiTamaño = new SizeF(24, 24);
            
        }

        public override void Update()
        {
            
        }

        public override void Draw(Graphics Graph)
        {
            Graph.DrawImage(MiImagen, new RectangleF(MiCoordenada, MiTamaño));
        }
    }
}
