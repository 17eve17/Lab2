using System;

class Point
{
    private double x;
    private double y;
    private string name;

    public Point(double x, double y, string name)
    {
        this.x = x;
        this.y = y;
        this.name = name;
    }

    public double X
    {
        get { return x; }
    }

    public double Y
    {
        get { return y; }
    }

    public string Name
    {
        get { return name; }
    }
}

class Figure
{

    private Point[] points;


    public Figure(Point point1, Point point2, Point point3)
    {
        points = new Point[] { point1, point2, point3 };
    }

    public Figure(Point point1, Point point2, Point point3, Point point4)
    {
        points = new Point[] { point1, point2, point3, point4 };
    }

    public Figure(Point point1, Point point2, Point point3, Point point4, Point point5)
    {
        points = new Point[] { point1, point2, point3, point4, point5 };
    }

    public double GetSideLength(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    }

    public void CalculatePerimeter()
    {
        double perimeter = 0;

        for (int i = 0; i < points.Length; i++)
        {
            Point current = points[i];
            Point next = points[(i + 1) % points.Length]; 
            perimeter += GetSideLength(current, next);
        }

        Console.WriteLine($"Периметр багатокутника: {perimeter}");
    }

    public string GetFigureName()
    {
        switch (points.Length)
        {
            case 3: return "Трикутник";
            case 4: return "Чотирикутник";
            case 5: return "П'ятикутник";
            default: return "Невідомий багатокутник";
        }
    }
}

class Program
{
    static void Main()
    {
        Point A = new Point(0, 0, "A");
        Point B = new Point(4, 0, "B");
        Point C = new Point(4, 3, "C");

        Figure triangle = new Figure(A, B, C);

        Console.WriteLine($"Назва фігури: {triangle.GetFigureName()}");

        triangle.CalculatePerimeter();
    }
}
