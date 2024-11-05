using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    abstract class Shape
    {
        private int x, y; //Coordinates
        private Color color;

        public Shape(int x, int y, Color color)
        {
            X = x;
            Y = y;
            ShapeColor = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Color ShapeColor { get; set; }

        public abstract double CalculateArea();
        public abstract void Draw(Graphics g);
        public virtual void MoveTo(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
        public virtual void Resize(int newSize) { }
        public abstract bool ContainsPoint(Point point);
    }
}
