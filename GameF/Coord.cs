using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameF
{
    struct Coord
    {
        public int x;
        public int y;

        public Coord (int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool OnBoard (int size)
        {
            if (x < 0 || x > size - 1)
            {
                return false;
            }
            if (y < 0 || y > size - 1)
            {
                return false;
            }
            return true;
        }
    }
}
