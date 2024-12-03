using System;
using System.Text;
public class Function
{
    protected double a0, a1, b0, b1, x0;
    public Function(bool skipInput = false)
    {
        if (!skipInput)
        {
            EnterCoefficients();
            EnterX();
        }
    }
    public virtual void EnterCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти функції:");
        Console.WriteLine("Чисельник:");
        Console.Write("a0 = ");
        while (!double.TryParse(Console.ReadLine(), out a0))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("a0 = ");
        }
        Console.Write("a1 = ");
        while (!double.TryParse(Console.ReadLine(), out a1))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("a1 = ");
        }
        Console.WriteLine("\nЗнаменник:");
        Console.Write("b0 = ");
        while (!double.TryParse(Console.ReadLine(), out b0))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("b0 = ");
        }
        Console.Write("b1 = ");
        while (!double.TryParse(Console.ReadLine(), out b1))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("b1 = ");
        }
    }
    public virtual void EnterX()
    {
        Console.Write("\nВведіть значення для x0 = ");
        while (!double.TryParse(Console.ReadLine(), out x0))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("x0 = ");
        }
    }
    public double GetA0() => a0;
    public double GetA1() => a1;
    public double GetB0() => b0;
    public double GetB1() => b1;
    public double GetX0() => x0;
    public virtual void ShowCoefficients()
    {
        Console.WriteLine("\nКоефіцієнти функції:");
        Console.WriteLine($"{a1}x + {a0}");
        Console.WriteLine("------");
        Console.WriteLine($"{b1}x + {b0}");
    }
    public virtual void FindValue()
    {
        double denominator = b1 * x0 + b0;
        if (denominator == 0)
        {
            Console.WriteLine("Знаменник дорівнює 0, розрахунок неможливий.");
        }
        else
        {
            double result = (a1 * x0 + a0) / denominator;
            Console.WriteLine($"\nЗначення дробово-лінійної функції при x0 = {x0}: {result}");
        }
    }
}
public class FractionFunction : Function
{
    private double a2, b2;
    public FractionFunction(Function linearFunction)
        : base(true)
    {
        this.a0 = linearFunction.GetA0();
        this.a1 = linearFunction.GetA1();
        this.b0 = linearFunction.GetB0();
        this.b1 = linearFunction.GetB1();
        this.x0 = linearFunction.GetX0();
        Console.WriteLine("\nЧи бажаєте ви залишити попередні коефіцієнти чисельника та знаменника? (yes/no)");
        string answer = Console.ReadLine().ToLower();
        if (answer == "no")
        {
            EnterCoefficients();
        }
        Console.WriteLine("\nЧи бажаєте ви залишити попереднє значення x0? (yes/no)");
        answer = Console.ReadLine().ToLower();
        if (answer == "no")
        {
            EnterX();
        }
        Console.WriteLine("\nВведіть додаткові коефіцієнти для квадратичної функції:");
        Console.Write("a2 = ");
        while (!double.TryParse(Console.ReadLine(), out a2))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("a2 = ");
        }
        Console.Write("b2 = ");
        while (!double.TryParse(Console.ReadLine(), out b2))
        {
            Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            Console.Write("b2 = ");
        }
    }
    public override void ShowCoefficients()
    {
        Console.WriteLine("Коефіцієнти функції");
        Console.WriteLine($"{a2}x^2 + {a1}x + {a0}");
        Console.WriteLine("-------------");
        Console.WriteLine($"{b2}x^2 + {b1}x + {b0}");
    }
    public override void FindValue()
    {
        double denominator = b2 * Math.Pow(x0, 2) + b1 * x0 + b0;
        if (denominator == 0)
        {
            Console.WriteLine("Знаменник дорівнює 0, розрахунок неможливий.");
        }
        else
        {
            double result = (a2 * Math.Pow(x0, 2) + a1 * x0 + a0) / denominator;
            Console.WriteLine($"\nЗначення дробової функції при x0 = {x0}: {result}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Function linearFunction = new Function();
        linearFunction.ShowCoefficients();
        linearFunction.FindValue();
        FractionFunction quadraticFunction = new FractionFunction(linearFunction);
        quadraticFunction.ShowCoefficients();
        quadraticFunction.FindValue();
    }
}