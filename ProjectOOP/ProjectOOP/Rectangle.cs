using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class Rectangle : Shape
    {
        private int a, b;

        public Rectangle(int x, int y, int a, int b, Color color)
            :base(x,y,color)
        {
            A = a;
            B = b;
        }

        public int A { get; set; }
        public int B { get; set; }
        public override double CalculateArea()
        {
            return A * B;
        }

        public override bool ContainsPoint(Point point)
        {
            int topLeftX = X - (A / 2);
            int topLeftY = Y - (B / 2);

            return point.X >= topLeftX && point.X <= topLeftX + A && point.Y >= topLeftY && point.Y <= topLeftY + B;
        }

        public override void Draw(Graphics g)
        {
            int topLeftX = X - (A / 2);
            int topLeftY = Y - (B / 2);

            Brush fillBrush = new SolidBrush(ShapeColor);
            g.DrawRectangle(Pens.Black, topLeftX, topLeftY, A, B);
            g.FillRectangle(fillBrush, topLeftX, topLeftY, A, B);
        }
        public void Resize(int sideA, int sideB)
        {
            A = sideA;
            B = sideB;
        }
    }
}
