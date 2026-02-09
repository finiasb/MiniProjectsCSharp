using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._3_Snake
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


        public void RepozitionareStanga(int nouX, int nouY)
        {
            this.x = nouX - 20;
            this.y = nouY;
        }
        public void RepozitionareJos(int nouX, int nouY)
        {
            this.x = nouX;
            this.y = nouY - 20;
        }

        public void deseneaza(Graphics g, Color color)
        {
            Brush brush = new SolidBrush(color);
            Rectangle rec = new Rectangle(x, y, 20, 20);
            g.FillEllipse(brush, rec);
        }
    }
}
