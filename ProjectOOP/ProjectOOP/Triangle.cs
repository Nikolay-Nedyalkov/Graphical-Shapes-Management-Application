using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class Triangle : Shape
    {
        private int a, b, c;

        public Triangle(int x, int y, int a, int b, int c, Color color)
            : base(x, y, color)
        {
            A = a;
            B = b;
            C = c;
        }

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override double CalculateArea()
        {
            double p = (A + B + C) / 2;
            return Math.Round(Math.Sqrt(p * (p - A) * (p - B) * (p - C)));
        }
        public override bool ContainsPoint(Point point)
        {
            Point v0 = new Point(X - (A / 2), Y + (C / 2));
            Point v1 = new Point(X + (A / 2), Y + (C / 2));
            Point v2 = new Point(X, Y - (B / 2));

            Point v0ToPoint = new Point(point.X - v0.X, point.Y - v0.Y);
            Point v0ToV1 = new Point(v1.X - v0.X, v1.Y - v0.Y);
            Point v0ToV2 = new Point(v2.X - v0.X, v2.Y - v0.Y);

            double dot00 = v0ToV1.X * v0ToV1.X + v0ToV1.Y * v0ToV1.Y;
            double dot01 = v0ToV1.X * v0ToV2.X + v0ToV1.Y * v0ToV2.Y;
            double dot02 = v0ToV1.X * v0ToPoint.X + v0ToV1.Y * v0ToPoint.Y;
            double dot11 = v0ToV2.X * v0ToV2.X + v0ToV2.Y * v0ToV2.Y;
            double dot12 = v0ToV2.X * v0ToPoint.X + v0ToV2.Y * v0ToPoint.Y;

            double invDenom = 1 / (dot00 * dot11 - dot01 * dot01);
            double u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            double v = (dot00 * dot12 - dot01 * dot02) * invDenom;

            return (u >= 0) && (v >= 0) && (u + v <= 1);
        }

        public override void Draw(Graphics g)
        {
            Point[] points = new Point[]
            {
                new Point(X - (A / 2), Y + (C / 2)),
                new Point(X + (A / 2), Y + (C / 2)),
                new Point(X, Y - (B / 2)),
            };

            Brush fillBrush = new SolidBrush(ShapeColor);
            g.DrawPolygon(Pens.Black, points);
            g.FillPolygon(fillBrush, points);
        }
        public void Resize(int sideA, int sideB, int sideC)
        {
            A = sideA;
            B = sideB;
            C = sideC;
        }
    }
}
