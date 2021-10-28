using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_In_Tetris
{
    class Location2D
    {
        public int x { get; set; }
        public int y { get; set; }

        public Location2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
