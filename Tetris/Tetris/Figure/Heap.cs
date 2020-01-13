using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Heap : Figure
    {
        int score = 0;
        public Heap()
        {
            pList = new List<Point>();

        }
        public void AddInHeap(Tetriminos tetriminos)
        {
            foreach (Point p in tetriminos.FList())
                pList.Add(p);
        }
        public void FullLine()
        {
            int line;
            for (int y = 23; y > 0; y--)
            {
                line = 0;
                for (int x = 2; x < 13; x++)
                    foreach (Point pHeap in pList)
                        if (pHeap.CoorX() == x && pHeap.CoorY() == y)
                            line++;

                if (line >= 10)
                {
                    score += 100;
                    List<Point> tempList = new List<Point>();
                    tempList.Clear();

                    foreach (Point pHeap in pList)
                    {
                        if (pHeap.CoorY() != y)
                            tempList.Add(pHeap);
                        pHeap.Clear();
                    }

                    pList.Clear();
                    pList = tempList;

                    foreach (Point p in pList)
                    {
                        if (p.CoorY() < y)
                            p.Move(1, Direction.DOWN);
                        p.Draw('*');
                    }
                    y++;
                }
            }
        }
        public int Score()
        {
            return score;
        }
    }
}