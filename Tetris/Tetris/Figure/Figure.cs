using System;
using System.Collections.Generic;

namespace Tetris
{
    class Figure
    {
        protected List<Point> pList;

        public void Draw()
        {
            foreach (Point p in pList)
                p.Draw();
        }

        internal Direction DirectKey(ConsoleKey key)
        {
            Direction direction = Direction.DOWN;
            if (key == ConsoleKey.LeftArrow)
                direction = (Direction.LEFT);
            else if (key == ConsoleKey.RightArrow)
                direction = (Direction.RIGHT);
            return direction;
        }

        internal List<Point> FList()
        {
            List<Point> fList = new List<Point>(pList);
            return fList;
        }

        internal bool IsHit(Figure figure, Direction direction)
        {
            foreach (Point p in pList)
                if (figure.IsHit(p, direction))
                    return true;

            return false;
        }

        private bool IsHit(Point p, Direction direction)
        {
            foreach (Point pCheck in pList)
                if (p.IsHit(pCheck, direction))
                    return true;

            return false;
        }
    }

}
