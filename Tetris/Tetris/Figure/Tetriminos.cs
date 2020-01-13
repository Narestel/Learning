using System;
using System.Collections.Generic;

namespace Tetris
{
    class Tetriminos : Figure
    {
        int random;
        int x = 6;
        int y = 3;
        public Tetriminos()
        {
            random = new Random().Next(0, 7);
            pList = new List<Point>();

            switch (random)
            {
                case 0: //Line
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x, y + 1);
                        pList.Add(p);
                        p = new Point(x, y + 2);
                        pList.Add(p);
                        p = new Point(x, y - 1);
                        pList.Add(p);
                    };
                    break;
                case 1: //square
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x, y + 1);
                        pList.Add(p);
                        p = new Point(x + 1, y);
                        pList.Add(p);
                        p = new Point(x + 1, y + 1);
                        pList.Add(p);
                    };
                    break;
                case 2: //T-polyomino
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x, y + 1);
                        pList.Add(p);
                        p = new Point(x, y - 1);
                        pList.Add(p);
                        p = new Point(x + 1, y);
                        pList.Add(p);
                    };
                    break;
                case 3: //L
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x + 1, y);
                        pList.Add(p);
                        p = new Point(x + 2, y);
                        pList.Add(p);
                        p = new Point(x, y + 1);
                        pList.Add(p);
                    };
                    break;
                case 4: //J
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x - 1, y);
                        pList.Add(p);
                        p = new Point(x - 2, y);
                        pList.Add(p);
                        p = new Point(x, y + 1);
                        pList.Add(p);
                    };
                    break;
                case 5: //S
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x, y - 1);
                        pList.Add(p);
                        p = new Point(x + 1, y);
                        pList.Add(p);
                        p = new Point(x + 1, y + 1);
                        pList.Add(p);
                    };
                    break;
                case 6: //Z
                    {
                        Point p = new Point(x, y);
                        pList.Add(p);
                        p = new Point(x, y - 1);
                        pList.Add(p);
                        p = new Point(x - 1, y);
                        pList.Add(p);
                        p = new Point(x - 1, y + 1);
                        pList.Add(p);
                    };
                    break;
            }
        }
        internal void MoveWithKey(ConsoleKey key)
        {
            Direction direction = DirectKey(key);
            Move(direction);
        }

        public void Move(Direction direction)
        {
            foreach (Point p in pList)
            {
                Point cleaner = new Point(p);
                cleaner.Clear();
                p.Move(1, direction);
            }
            Draw();
        }

        internal void Turn()
        {
            List<Point> pTurnList = new List<Point>();
            for (int i = 0; i <= 3; i++)
            {
                Point p = new Point(pList[0].CoorX() + (pList[i].CoorY() - pList[0].CoorY()),
                    pList[0].CoorY() - (pList[i].CoorX() - pList[0].CoorX()));
                pTurnList.Add(p);
            }
            foreach (Point pOld in pList)
                pOld.Clear();

            pList = pTurnList;
        }
        internal void Slide()
        {
            foreach (Point p in pList)
            {
                if (p.CoorX() < 2)
                    Move(Direction.RIGHT);

                if (p.CoorX() > 11)
                    Move(Direction.LEFT);
            }

        }
    }
}
