using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CLIENT
{
    class GOLD
    {
        public Point pos;
        public int value;
        public Label lb;
        public GOLD(int x,int y,int val)
        {
            this.pos = new Point(x, y);
            this.value = val;
            this.lb = new Label()
            {
                Location =this.pos,Width=Cons.width_gold,Height=Cons.height_gold,Text=Convert.ToString(this.value),BorderStyle=BorderStyle.FixedSingle,TextAlign=ContentAlignment.MiddleCenter,BackColor=Color.Yellow
            };
        }
        public void setlb(int Y)
        {
            Point p = this.pos;
            p.Y = Y;
            this.lb.Location = p;
        }
    }
}
