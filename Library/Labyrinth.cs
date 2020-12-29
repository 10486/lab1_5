using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Library
{
    public class Labyrinth
    {
        public bool[][] Field { get; private set; }
        public int Height { get; private set; } 
        public int Width { get; private set; }

        public Labyrinth(bool[][] field)
        {
            if(field is null)
            {
                throw new ArgumentNullException($"{nameof(field)} is null");
            }
            Field = field;
            Width = field.Length;
            Height = field[0].Length;
        }
        public Labyrinth()
        {
            Field = new bool[][]
            {
                new bool[]{true, true, true, false},
                new bool[]{ false, false, true, false},
                new bool[]{ true, true, true, false},
                new bool[]{ true, false, false, false},
                new bool[]{ true, true, true, true},
            };
            Width = 4;
            Height = 5;
        }
        /// <summary>
        /// Проверка на то что в клетку можно зайти
        /// </summary>
        /// <param name="point">Координаты клетки</param>
        /// <returns>true если можно, в ином случае false</returns>
        public bool Clear(Point point)
        {
            if (point.X >= Width || point.X < 0 ||
                point.Y >= Height || point.Y < 0)
            {
                return false;
            }
            return Field[point.Y][point.X];
        }
    }
}
