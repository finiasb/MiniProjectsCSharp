using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._1___Animate_name
{
    public class Cerc
    {
        public int x {  get; set; }
        public int y { get; set; }
        
        public Cerc(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }

        public void Deseneaza(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, x, y, 30, 30);
        }
    }
}
