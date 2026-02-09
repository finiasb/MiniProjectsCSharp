using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._3_Snake
{
    public class CercMancare
    {
        public int x { get; set; }
        public int y { get; set; }

        public CercMancare(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void ReseteazaPozitie(int nouX, int nouY)
        {
            this.x = nouX;
            this.y = nouY;
        }

        public void deseneazaMancare(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            Rectangle rec = new Rectangle(x, y, 20, 20);
            g.FillEllipse(brush, rec);
        }
    }
}
