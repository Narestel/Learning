using System;

namespace Tetris
{
    class Point
    {
        int x;
        int y;
        char sym = '*';
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public void Draw(char sym)
        {
            this.sym = sym;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.LEFT)
                x -= offset;
            else if (direction == Direction.RIGHT)
                x += offset;
            else if (direction == Direction.DOWN)
                y += offset;
        }

        public bool IsHit(Point pCheck, Direction direction)
        {
            if (direction == Direction.LEFT)
                return (pCheck.x - 1 == x && pCheck.y == y);
            if (direction == Direction.RIGHT)
                return (pCheck.x + 1 == x && pCheck.y == y);
            if (direction == Direction.DOWN)
                return (pCheck.x == x && pCheck.y+1 == y);
            else
                return false;
        }

        internal int CoorX()
        {
            return x;
        }
        internal int CoorY()
        {
            return y;
        }
    }
}
