using System;

class Line
{
    private double a1;
    private double a2;
    private double a0;

    public double A1
    {
        get { return a1; }
        set { a1 = value; }
    }
    public double A2
    {
        get { return a2; }
        set { a2 = value; }
    }
    public double A0
    {
        get { return a0; }
        set { a0 = value; }
    }

    public Line(double a1, double a2, double a0)
    {
        A1 = a1;
        A2 = a2;
        A0 = a0;
    }

    public virtual void Coefficients()
    {
        Console.WriteLine($"Рівняння прямої: {A1}x + {A2}y + {A0} = 0");
    }

    public virtual void Check(params double[] coordinates)
    {
        if (coordinates.Length == 2)
        {
            double x = coordinates[0];
            double y = coordinates[1];
            if (A1 * x + A2 * y + A0 == 0)
            {
                Console.WriteLine($"Точка ({x}, {y}) належить прямій.");
            }
            else
            {
                Console.WriteLine($"Точка ({x}, {y}) не належить прямій.");
            }
        }
        else
        {
            Console.WriteLine("Неправильна кількість координат для прямої.");
        }
    }
}

class Hyperplane : Line
{
    public double A3 { get; set; }
    public double A4 { get; set; }

    public Hyperplane(double a4, double a3, double a2, double a1, double a0)
        : base(a1, a2, a0)
    {
        A3 = a3;
        A4 = a4;
    }

    public override void Coefficients()
    {
        Console.WriteLine($"Рівняння гіперплощини: {A4}x4 + {A3}x3 + {A2}x2 + {A1}x1 + {A0} = 0");
    }

    public override void Check(params double[] coordinates)
    {
        if (coordinates.Length == 4)
        {
            double x1 = coordinates[0];
            double x2 = coordinates[1];
            double x3 = coordinates[2];
            double x4 = coordinates[3];
            if (A4 * x4 + A3 * x3 + A2 * x2 + A1 * x1 + A0 == 0)
            {
                Console.WriteLine($"Точка ({x1}, {x2}, {x3}, {x4}) належить гіперплощині.");
            }
            else
            {
                Console.WriteLine($"Точка ({x1}, {x2}, {x3}, {x4}) не належить гіперплощині.");
            }
        }
        else
        {
            Console.WriteLine("Неправильна кількість координат для гіперплощини.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        double userChoice;
        Line baseObj = null;
        do
        {
            userChoice = GetValidInput("0 для лінії, 1 для гіперплощини, -1 щоб вийти");

            if (userChoice == 0)
            {
                Console.WriteLine("Введіть коефіцієнти для лінії (a1, a2, a0):");
                double a1 = GetValidInput("a1");
                double a2 = GetValidInput("a2");
                double a0 = GetValidInput("a0");
                baseObj = new Line(a1, a2, a0);
            }
            else if (userChoice == 1)
            {
                Console.WriteLine("Введіть коефіцієнти для гіперплощини (a4, a3, a2, a1, a0):");
                double a4 = GetValidInput("a4");
                double a3 = GetValidInput("a3");
                double a2 = GetValidInput("a2");
                double a1 = GetValidInput("a1");
                double a0 = GetValidInput("a0");
                baseObj = new Hyperplane(a4, a3, a2, a1, a0);
            }
            else if (userChoice == -1)
            {
                break;
            }

            if (baseObj != null)
            {
                baseObj.Coefficients();
                Console.WriteLine("Введіть координати точки для перевірки належності:");
                double[] coordinates = GetCoordinates(baseObj is Hyperplane ? 4 : 2);
                baseObj.Check(coordinates);
            }

        } while (true);
    }

    static double GetValidInput(string prompt)
    {
        double result;
        Console.Write($"{prompt}: ");
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Invalid input, please enter a number.");
            Console.Write($"{prompt}: ");
        }
        return result;
    }

    static double[] GetCoordinates(int num)
    {
        double[] coords = new double[num];
        for (int i = 0; i < num; i++)
        {
            coords[i] = GetValidInput($"Enter coordinate x{i + 1}");
        }
        return coords;
    }
}