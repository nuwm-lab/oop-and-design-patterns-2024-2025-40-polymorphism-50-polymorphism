using System;

namespace LabWork
{
    // Базовий клас: квадратичне рівняння
    class QuadraticEquation
    {
        protected double b2, b1, b0; // Коефіцієнти рівняння

        public virtual void SetCoefficients()
        {
            Console.WriteLine("Введiть коефiцiєнти для квадратичного рiвняння:");
            Console.Write("b2: ");
            b2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b1: ");
            b1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b0: ");
            b0 = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void PrintEquation()
        {
            Console.WriteLine($"Квадратичне рiвняння: {b2}x^2 + {b1}x + {b0} = 0");
        }

        public virtual bool IsRoot(double x)
        {
            double result = b2 * x * x + b1 * x + b0;
            return Math.Abs(result) < 1e-6;
        }

        public virtual void FindRoots()
        {
            double discriminant = b1 * b1 - 4 * b2 * b0;
            if (discriminant > 0)
            {
                double root1 = Math.Round((-b1 + Math.Sqrt(discriminant)) / (2 * b2), 2);
                double root2 = Math.Round((-b1 - Math.Sqrt(discriminant)) / (2 * b2), 2);
                Console.WriteLine($"Два коренi: x1 = {root1}, x2 = {root2}");
            }
            else if (Math.Abs(discriminant) < 1e-6)
            {
                double root = Math.Round(-b1 / (2 * b2), 2);
                Console.WriteLine($"Один корiнь: x = {root}");
            }
            else
            {
                Console.WriteLine("Рiвняння не має дiйсних коренiв.");
            }
        }
    }

    // Похідний клас: кубічне рівняння
    class CubicEquation : QuadraticEquation
    {
        private double a3; // Додатковий коефіцієнт

        public override void SetCoefficients()
        {
            Console.WriteLine("Введiть коефiцiєнти для кубiчного рiвняння:");
            Console.Write("a3: ");
            a3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a2 (b2): ");
            b2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a1 (b1): ");
            b1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a0 (b0): ");
            b0 = Convert.ToDouble(Console.ReadLine());
        }

        public override void PrintEquation()
        {
            Console.WriteLine($"Кубiчне рiвняння: {a3}x^3 + {b2}x^2 + {b1}x + {b0} = 0");
        }

        public override bool IsRoot(double x)
        {
            double result = a3 * x * x * x + b2 * x * x + b1 * x + b0;
            return Math.Abs(result) < 1e-6;
        }

        public override void FindRoots()
        {
            Console.WriteLine("Реалiзацiя пошуку коренiв для кубiчного рiвняння потребує спецiального алгоритму.");
            Console.WriteLine("Рекомендується використати чисельний метод (не реалiзовано).");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Виберiть тип рiвняння:");
            Console.WriteLine("1 - Квадратичне рiвняння");
            Console.WriteLine("2 - Кубiчне рiвняння");
            Console.Write("Ваш вибiр: ");
            string userChoice = Console.ReadLine();

            QuadraticEquation equation;

            if (userChoice == "1")
            {
                equation = new QuadraticEquation();
            }
            else if (userChoice == "2")
            {
                equation = new CubicEquation();
            }
            else
            {
                Console.WriteLine("Неправильний вибiр!");
                return;
            }

            equation.SetCoefficients();
            equation.PrintEquation();
            equation.FindRoots();

            Console.Write("Введіть значення x для перевірки чи є воно коренем: ");
            double x = Convert.ToDouble(Console.ReadLine());
            bool isRoot = equation.IsRoot(x);
            Console.WriteLine(isRoot
                ? $"Число x = {x} є коренем рiвняння."
                : $"Число x = {x} не є коренем рiвняння.");
        }
    }
}
