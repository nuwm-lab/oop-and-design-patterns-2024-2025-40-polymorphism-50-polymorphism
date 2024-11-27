using System;

class Triangle
{
    // Координати трьох вершин трикутника
    protected double x1, y1, x2, y2, x3, y3;

    // Віртуальний метод для задання координат трьох вершин трикутника
    public virtual void SetCoordinates(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
    }

    // Віртуальний метод для виведення координат вершин трикутника
    public virtual void DisplayCoordinates()
    {
        Console.WriteLine($"Triangle vertices: ({x1},{y1}), ({x2},{y2}), ({x3},{y3})");
    }

    // Віртуальний метод для обчислення площі трикутника за допомогою формули площі трикутника
    public virtual double CalculateArea()
    {
        return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
    }
}

class ConvexQuadrilateral : Triangle
{
    private double x4, y4;

    // Метод для чотирикутника
    public void SetCoordinates(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        // Викликаємо метод базового класу для задання перших трьох вершин
        base.SetCoordinates(x1, y1, x2, y2, x3, y3);
        this.x4 = x4;
        this.y4 = y4;
    }

    public override void DisplayCoordinates()
    {
        base.DisplayCoordinates();
        Console.WriteLine($"Fourth vertex: ({x4},{y4})");
    }

    public override double CalculateArea()
    {
        double area1 = base.CalculateArea();
        double area2 = Math.Abs((x1 * (y3 - y4) + x3 * (y4 - y1) + x4 * (y1 - y3)) / 2.0);
        return area1 + area2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose the object to create (1 for Triangle, 2 for Convex Quadrilateral): ");
        char userChoose = Console.ReadKey().KeyChar; // Читаємо вибір користувача
        Console.WriteLine();

        Triangle shape; // Вказівник на базовий клас

        if (userChoose == '1')
        {
            shape = new Triangle(); // Створюємо об'єкт класу Triangle

            Console.WriteLine("Enter coordinates for Triangle (x1 y1 x2 y2 x3 y3):");
            var coords = Console.ReadLine().Split();
            shape.SetCoordinates(
                double.Parse(coords[0]), double.Parse(coords[1]),
                double.Parse(coords[2]), double.Parse(coords[3]),
                double.Parse(coords[4]), double.Parse(coords[5])
            );
        }
        else
        {
            shape = new ConvexQuadrilateral(); // Створюємо об'єкт класу ConvexQuadrilateral

            Console.WriteLine("Enter coordinates for Convex Quadrilateral (x1 y1 x2 y2 x3 y3 x4 y4):");
            var coords = Console.ReadLine().Split();
            ((ConvexQuadrilateral)shape).SetCoordinates(
                double.Parse(coords[0]), double.Parse(coords[1]),
                double.Parse(coords[2]), double.Parse(coords[3]),
                double.Parse(coords[4]), double.Parse(coords[5]),
                double.Parse(coords[6]), double.Parse(coords[7])
            );
        }

        // Виводимо координати об'єкта
        shape.DisplayCoordinates();
        // Обчислюємо та виводимо площу
        Console.WriteLine($"Area: {shape.CalculateArea()}");
    }
}