using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOM
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point()
        {

        }

        public Point(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point operator +(Point a, double d)
        {
            return new Point(a.X * (float)d, a.Y * (float)d);
        }

        public static Point operator -(Point a, double d)
        {
            return new Point(a.X - (float)d, a.Y - (float)d);
        }

        public static Point operator *(Point a, double d)
        {
            return new Point(a.X * (float)d, a.Y * (float)d);
        }

        public static Point operator /(Point a, double d)
        {
            return new Point(a.X / (float)d, a.Y / (float)d);
        }

        public static Point operator *(double d, Point a)
        {
            return new Point(a.X * (float)d, a.Y * (float)d);
        }

        public static Point operator /(double d, Point a)
        {
            return new Point(a.X / (float)d, a.Y / (float)d);
        }


    }

    public abstract class Shape
    {
        public abstract Point RandomPointIn();
        public abstract void AddPoint(Point p);
        public abstract void Reset();
        public abstract bool IsComplete();
        public abstract void Draw(PictureBox pictureBox);
        public abstract void Draw(object sender, System.Windows.Forms.PaintEventArgs e);
    }

    public class Triangle : Shape
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        public Triangle()
        {

        }

        public Triangle(Point Point1, Point Point2, Point Point3)
        {
            this.Point1 = Point1;
            this.Point2 = Point2;
            this.Point3 = Point3;
        }

        public override void AddPoint(Point p)
        {
            if (Point1 == null)
            {
                Point1 = p;
            }
            else if (Point2 == null)
            {
                Point2 = p;
            }
            else if (Point3 == null)
            {
                Point3 = p;
            }
            else
            {
                Console.WriteLine("Cant add points to triangle");
            }
        }

        public override Point RandomPointIn()
        {
            Random random = new Random();
            float f1 = (float)random.NextDouble();
            float f2 = (float)random.NextDouble();

            if (f1 > f2)
            {
                float tmp = f1;
                f1 = f2;
                f2 = tmp;
            }

            float PointX = f1 * Point1.X + (f2 - f1) * Point2.X + (1 - f2) * Point3.X;
            float PointY = f1 * Point1.Y + (f2 - f1) * Point2.Y + (1 - f2) * Point3.Y;
            return new Point(PointX, PointY);
        }

        public override void Reset()
        {
            Point1 = null;
            Point2 = null;
            Point3 = null;
        }

        public override bool IsComplete()
        {
            if (Point1 == null || Point2 == null || Point3 == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Draw(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.White);

            if (Point1 != null && Point2 == null && Point3 == null)
            {
                g.FillRectangle(Brushes.Black, Point1.X, Point1.Y, 3, 3);
            }

            if ( Point1 != null && Point2 != null)
            {
                g.DrawLine(Pens.Black, Point1.X, Point1.Y, Point2.X, Point2.Y);
            }
            if (Point2 != null && Point3 != null)
            {
                g.DrawLine(Pens.Black, Point2.X, Point2.Y, Point3.X, Point3.Y);
            }
            if (Point1 != null && Point3 != null)
            {
                g.DrawLine(Pens.Black, Point1.X, Point1.Y, Point3.X, Point3.Y);
            }
        }

        public override void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (Point1 != null && Point2 == null && Point3 == null)
            {
                e.Graphics.FillRectangle(Brushes.Black, Point1.X, Point1.Y, 3, 3);
            }

            if (Point1 != null && Point2 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point1.X, Point1.Y, Point2.X, Point2.Y);
            }
            if (Point2 != null && Point3 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point2.X, Point2.Y, Point3.X, Point3.Y);
            }
            if (Point1 != null && Point3 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point1.X, Point1.Y, Point3.X, Point3.Y);
            }
        }

        public static double Area(Point a, Point b, Point c)
        {
            return ((b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y));
        }

        public static Boolean IsInside(Point v1, Point v2, Point v3, Point test)
        {
            bool a, b, c;

            a = Area(test, v1, v2) < 0.0 ? true : false;
            b = Area(test, v2, v3) < 0.0 ? true : false;
            c = Area(test, v3, v1) < 0.0 ? true : false;
            return ((a == b) && (a == c));
        }
    }

    public class Quadrangle : Shape
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        public Point Point4 { get; set; }

        List<Triangle> triangles = new List<Triangle>();

        public Quadrangle()
        {

        }

        public Quadrangle(Point Point1, Point Point2, Point Point3, Point Point4)
        {
            this.Point1 = Point1;
            this.Point2 = Point2;
            this.Point3 = Point3;
            this.Point4 = Point4;
            SplitToTriangles();
        }

        public void SplitToTriangles()
        {
            triangles.Clear();
            triangles.Add(new Triangle(Point1, Point2, Point3));
            triangles.Add(new Triangle(Point3, Point4, Point1));
        }

        public override Point RandomPointIn()
        {
            int triangleCount = triangles.Count;
            Random random = new Random();
            int rand = random.Next(0, triangleCount);
            return triangles[rand].RandomPointIn();
        }

        public override void Reset()
        {
            Point1 = null;
            Point2 = null;
            Point3 = null;
            Point4 = null;
            triangles = new List<Triangle>();
        }

        public override void AddPoint(Point p)
        {
            if (Point1 == null)
            {
                Point1 = p;
            }
            else if (Point2 == null)
            {
                Point2 = p;
            }
            else if (Point3 == null)
            {
                Point3 = p;
            }
            else if (Point4 == null)
            {
                Point4 = p;
                SplitToTriangles();
            }
            else
            {
                Console.WriteLine("Cant add points to triangle");
            }
        }

        public override bool IsComplete()
        {
            if (Point1 == null || Point2 == null || Point3 == null || Point4 == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Draw(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.White);

            if (Point1 != null && Point2 == null && Point3 == null && Point4 == null)
            {
                g.FillRectangle(Brushes.Black, Point1.X, Point1.Y, 3, 3);
            }

            if (Point1 != null && Point2 != null)
            {
                g.DrawLine(Pens.Black, Point1.X, Point1.Y, Point2.X, Point2.Y);
            }
            if (Point2 != null && Point3 != null)
            {
                g.DrawLine(Pens.Black, Point2.X, Point2.Y, Point3.X, Point3.Y);
            }
            if (Point3 != null && Point4 != null)
            {
                g.DrawLine(Pens.Black, Point3.X, Point3.Y, Point4.X, Point4.Y);
            }
            if (Point1 != null && Point4 != null)
            {
                g.DrawLine(Pens.Black, Point4.X, Point4.Y, Point1.X, Point1.Y);
            }
        }

        public override void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (Point1 != null && Point2 == null && Point3 == null && Point4 == null)
            {
                e.Graphics.FillRectangle(Brushes.Black, Point1.X, Point1.Y, 3, 3);
            }

            if (Point1 != null && Point2 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point1.X, Point1.Y, Point2.X, Point2.Y);
            }
            if (Point2 != null && Point3 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point2.X, Point2.Y, Point3.X, Point3.Y);
            }
            if (Point3 != null && Point4 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point3.X, Point3.Y, Point4.X, Point4.Y);
            }
            if (Point1 != null && Point4 != null)
            {
                e.Graphics.DrawLine(Pens.Black, Point4.X, Point4.Y, Point1.X, Point1.Y);
            }
        }
    }

    public class Circle : Shape
    {
        public Point CenterPoint { get; set; }
        public float Radius { get; set; }

        public Circle()
        {

        }

        public Circle(Point CenterPoint, float Radius)
        {
            this.CenterPoint = CenterPoint;
            this.Radius = Radius;
        }

        public override Point RandomPointIn()
        {
            Random random = new Random();

            float centerX = CenterPoint.X + (Radius / 2);
            float centerY = CenterPoint.Y + (Radius / 2);

            float angle = (float)random.NextDouble() * (float)Math.PI * 2;
            float radius = (float)random.NextDouble() * Radius;
            float x = centerX + (radius / 2) * (float)Math.Cos(angle);
            float y = centerY + (radius / 2) * (float)Math.Sin(angle);

            return new Point(x, y);
        }

        public override void Reset()
        {
            CenterPoint = null;
            Radius = 0;
        }

        public override void AddPoint(Point p)
        {
            if (CenterPoint == null)
            {
                CenterPoint = p;
            }
            else if (Radius == 0)
            {
                Radius = GetDistance(CenterPoint, p);

                float centerX = Math.Abs(CenterPoint.X - (Radius / 2));
                float centerY = Math.Abs(CenterPoint.Y - (Radius / 2));

                CenterPoint = new Point(centerX, centerY);
            }
            else
            {
                Console.WriteLine("Cant add points to triangle");
            }
        }

        public float GetDistance(Point point1, Point point2)
        {
            return (float)Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }

        public override bool IsComplete()
        {
            if (CenterPoint == null || Radius == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Draw(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.White);
            if (CenterPoint != null && Radius == 0)
            {
                g.FillRectangle(Brushes.Black, CenterPoint.X, CenterPoint.Y, 3, 3);
            }
            else if (CenterPoint != null && Radius != 0)
            {
                g.DrawEllipse(new Pen(Color.Black), CenterPoint.X, CenterPoint.Y, Radius, Radius);
            }
        }

        public override void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (CenterPoint != null && Radius == 0)
            {
                e.Graphics.FillRectangle(Brushes.Black, CenterPoint.X, CenterPoint.Y, 3, 3);
            }
            else if (CenterPoint != null && Radius != 0)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), CenterPoint.X, CenterPoint.Y, Radius, Radius);
            }
        }
    }

    public class Ellipse : Shape
    {
        public Point CenterPoint { get; set; }
        public float RadiusX { get; set; }
        public float RadiusY { get; set; }

        public Ellipse()
        {

        }

        public Ellipse(Point CenterPoint, float RadiusX, float RadiusY)
        {
            this.CenterPoint = CenterPoint;
            this.RadiusX = RadiusX;
            this.RadiusY = RadiusY;
        }



        public override Point RandomPointIn()
        {
            Random random = new Random();

            float centerX = CenterPoint.X + (RadiusX / 2);
            float centerY = CenterPoint.Y + (RadiusY / 2);

            float angle = (float)random.NextDouble() * (float)Math.PI * 2;
            float rad = 0;

            if (RadiusX >= RadiusY)
            {
                rad = RadiusY;
            }
            else
            {
                rad = RadiusX;
            }

            float radius = (float)random.NextDouble() * rad;

            float x = centerX + (float)(random.NextDouble() * ((RadiusX / 2) - 1) + 1) * (float)Math.Cos(angle);
            float y = centerY + (float)(random.NextDouble() * ((RadiusY / 2) - 1) + 1) * (float)Math.Sin(angle);

            return new Point(x, y);
        }

        public override void Reset()
        {
            CenterPoint = null;
            RadiusX = 0;
            RadiusY = 0;
        }

        public override void AddPoint(Point p)
        {
            if (CenterPoint == null)
            {
                CenterPoint = p;
            }
            else
            {
                Console.WriteLine("Cant add points to triangle");
            }
        }

        public override bool IsComplete()
        {
            if (CenterPoint == null || RadiusX == 0 || RadiusY == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Draw(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.White);
            g.DrawEllipse(new Pen(Color.Black), CenterPoint.X, CenterPoint.Y, RadiusX, RadiusY);
        }

        public override void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Black), CenterPoint.X, CenterPoint.Y, RadiusX, RadiusY);
        }
    }
}