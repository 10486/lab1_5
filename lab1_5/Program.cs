using Library;
using System;
using System.Drawing;

namespace lab1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Непосредственно лабиринт
            var lab = new Labyrinth();
            var stack = new Stack<Point>();
            // Начало лабиринта
            stack.Push(new Point(0, 0));
            FindWay(stack, lab);
            while(stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
        /// <summary>
        /// Функция для прохода по лабиринту
        /// </summary>
        /// <param name="stack">Стек для прохода по лабиринту</param>
        /// <param name="lab">Лабиринт</param>
        /// <returns>true если выход найден</returns>
        static bool FindWay(Stack<Point> stack, Labyrinth lab)
        {
            var last = stack.Check();
            // Если дошли до конца возвращаем true
             if (last.X == lab.Width - 1 && last.Y == lab.Height - 1)
            {
                return true;
            }
            return Move(stack, lab, new Point(last.X + 1, last.Y)) ||
                Move(stack, lab, new Point(last.X - 1, last.Y)) ||
                Move(stack, lab, new Point(last.X, last.Y + 1)) ||
                Move(stack, lab, new Point(last.X, last.Y - 1));
        }
        /// <summary>
        /// Движение по лабиринту
        /// </summary>
        /// <param name="stack">Стек для движения по лабиринту</param>
        /// <param name="lab">Лабиринт</param>
        /// <param name="to">Точка в которую мы идем</param>
        /// <returns>true если мы можем из этой точки дойти до конца лабиринта</returns>
        static bool Move(Stack<Point> stack, Labyrinth lab, Point to)
        {
            if (to.X < 0 || to.Y < 0)
            {
                return false;
            }
            // Не уходим за границы и не ходим по уже пройденным местам
            if (lab.Clear(to) && !stack.Contains(to))
            {
                stack.Push(to);
                if (FindWay(stack, lab))
                {
                    return true;
                }
                else
                {
                    stack.Pop();
                }
            }
            return false;
        }
    }
}
