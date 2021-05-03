using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameF
{
    public class Game
    {
        int size;
        Map map;
        Coord space;
        public int moves { get; private set; }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public Game(int size)
        {
            this.size = size;
            map = new Map(size);

        }
        public void Start(int seed)
        {
            int digit = 0;
            foreach (Coord xy in new Coord().YieldCoord(size))
            {
                map.Set(xy, ++digit);
            }

            space = new Coord(size);

            if (seed > 0)
            {
                Shuffle(seed);
            }
            moves = 0;
        }
        void Shuffle (int seed)
        {
            Random random = new Random(seed);
            for (int j = 0; j < seed; j++)
            {
                PressAt(random.Next(size), random.Next(size));
            }
        }
        public int PressAt(int x, int y)
        {
            return iPressAt(new Coord(x, y));
        }
        int iPressAt(Coord xy)
        {
            if (space.Equals(xy))
            {
                return 0;
            }

            if (xy.x !=space.x && xy.y != space.y) //если нажатие по диагонали 
            {
                return 0;
            }

            int iSteps = Math.Abs(xy.x - space.x) + Math.Abs(xy.y - space.y);

            //смещение координты +-1
            while (xy.x != space.x)
            {
                Shift(Math.Sign(xy.x - space.x), 0);
            }
            while (xy.y != space.y)
            {
                Shift(0, Math.Sign(xy.y - space.y));
            }

            moves += iSteps;

            return iSteps;
        }

        void Shift(int sx, int sy)
        {
            Coord next = space.Add(sx, sy); //сохранили коорд куда сдвигаемся 
            map.Copy(next, space);
            space = next;
        }
        public int GetDigitAt(int x, int y)
        {
            return iGetDigitAt(new Coord(x, y));
        }
        int iGetDigitAt(Coord xy)
        {
            if (space.Equals(xy))
            {
                return 0;
            }
            return map.Get(xy);//пустое место
        }
        public bool Solved()
        {
            if (!space.Equals(new Coord(size)))
            {
                return false;
            }

            int digit = 0;

            foreach (Coord xy in new Coord().YieldCoord(size))
            {
                //проверка 16 клетки
                if (map.Get(xy) != ++digit)
                {
                    return space.Equals(xy);
                }
            }

            return true;
        }
        public bool EndGame()
        {
            int digit = 0;
            foreach (Coord xy in new Coord().YieldCoord(size))
            {
                //проверка 16 клетки
                if (!(map.Get(xy) != ++digit))
                {
                    return space.Equals(xy);
                }
            }

            return true;
        }
    }
}
