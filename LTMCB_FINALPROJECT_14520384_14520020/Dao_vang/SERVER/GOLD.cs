using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SERVER
{

    class GOLD 
    {
        public Point pos;
        public int value;
        static Random a = new Random();
        static Random b = new Random();
        public GOLD(int x, int y, int val)
        {
            this.pos.X = x;
            this.pos.Y = y;
            this.value = val;
        }
        public GOLD()
        {
            
            this.pos.X = a.Next(50,450 );
            this.pos.Y = b.Next(50, 350);
            this.value = a.Next(1, 10)*10;
        }
        public string GOLDtoString()
        {
            string str = Convert.ToString(this.pos.X) +','+
            Convert.ToString(this.pos.Y) + ','+
            Convert.ToString(this.value) + '.';
            return str;
        }

    }

}
