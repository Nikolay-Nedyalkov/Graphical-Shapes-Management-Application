using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class Circle : Shape
    {
        private int r;
        public Circle(int x, int y, int r, Color color)
            : base(x, y, color)
        {
            R = r;
        }
        public int R { get; set; }

        public override double CalculateArea()
        {
            return Math.Round(Math.PI * R * R);
        }

        public override bool ContainsPoint(Point point)
        {
            return (Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2))) <= R;
        }

        public override void Draw(Graphics g)
        {
            Brush fillBrush = new SolidBrush(ShapeColor);
            int topLeftX = X - R;
            int topLeftY = Y - R;
            g.DrawEllipse(Pens.Black, topLeftX, topLeftY, 2 * R, 2 * R);
            g.FillEllipse(fillBrush, topLeftX, topLeftY, 2 * R, 2 * R);
        }

        public void Resize(int radius)
        {
            R = radius;
        }
    }
}