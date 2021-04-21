using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameF
{
    struct Map
    {
        private int size;
        int[,] map;
        public Map (int size)
        {
            this.size = size;
            map = new int[size, size];
        }
        public void Set(Coord xy, int value)
        {
            if (xy.OnBoard (size))
            {
                map[xy.x, xy.y] = value;
            }
        }
        public int Get(Coord xy)
        {
            if (xy.OnBoard(size))
            {
                return map[xy.x, xy.y];
            }
            return 0;
        }
    }
}
