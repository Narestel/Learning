using System.Collections.Generic;

namespace Tetris
{
    class Floor : Figure
    {
        public Floor(int mapHeight)
        {
            pList = new List<Point>();
            for (int x = 1; x < 12; x++)
            {
                Point p = new Point(x, 0, '+');
                pList.Add(p);
                Point p1 = new Point(x, mapHeight - 1, '+');
                pList.Add(p1);
            }
        }
    }
}