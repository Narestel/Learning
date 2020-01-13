using System.Collections.Generic;

namespace Tetris
{
    class Walls : Figure
    {
        public Walls(int mapHeight)
        {
            pList = new List<Point>();
            for (int y = 0; y < mapHeight; y++)
            {
                Point p = new Point(1, y, '+');
                pList.Add(p);
                Point p1 = new Point(12, y, '+');
                pList.Add(p1);
            }
        }
    }
}