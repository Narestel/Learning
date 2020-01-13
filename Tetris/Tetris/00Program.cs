using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetBufferSize(80, 25);

            Walls walls = new Walls(25);
            walls.Draw();
            Floor floor = new Floor(25);
            floor.Draw();
            Heap heap = new Heap();

            Tetriminos tetriminos = new Tetriminos();
            tetriminos.Draw();
            int count = 0;

            while (true)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (!walls.IsHit(tetriminos, tetriminos.DirectKey(key.Key)) &&
                        !heap.IsHit(tetriminos, tetriminos.DirectKey(key.Key)))
                    {
                        if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
                            tetriminos.MoveWithKey(key.Key);

                        else if (key.Key == ConsoleKey.DownArrow &&
                                !floor.IsHit(tetriminos, Direction.DOWN))
                        {
                            tetriminos.MoveWithKey(key.Key);
                            while (Console.KeyAvailable) //антизалипание клавиши
                                Console.ReadKey(false);
                        }
                        else if (key.Key == ConsoleKey.UpArrow)
                        {
                            if (!heap.IsHit(tetriminos, Direction.LEFT) &&
                                !heap.IsHit(tetriminos, Direction.RIGHT))
                            {
                                tetriminos.Turn();
                                tetriminos.Slide();
                                tetriminos.Draw();
                            }
                            while (Console.KeyAvailable)
                                Console.ReadKey(false);
                        }
                    }
                    Thread.Sleep(20);
                }

                if (floor.IsHit(tetriminos, Direction.DOWN) || heap.IsHit(tetriminos, Direction.DOWN))
                {
                    heap.AddInHeap(tetriminos);
                    heap.FullLine();

                    tetriminos = new Tetriminos();
                    tetriminos.Draw();
                    if (heap.IsHit(tetriminos, Direction.DOWN))
                    {
                        Thread.Sleep(500);
                        Console.Clear();
                        Console.SetCursorPosition(10, 5);
                        Console.Write("Game Over");
                        Console.SetCursorPosition(10, 7);
                        Console.Write("Ваши очки: {0}", heap.Score());
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                }

                count++;
                Thread.Sleep(80);
                if (count > 5)
                {
                    tetriminos.Move(Direction.DOWN);
                    count = 0;
                    walls.Draw();
                }
            }
        }
    }
}
