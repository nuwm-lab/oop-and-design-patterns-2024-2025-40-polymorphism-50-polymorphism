using System;
using System.Globalization;

namespace LabWork
{

    class EquilateralTriangle
    {
        public double SideLength { get; protected set; }
        public double Angle { get; private set; }

        public EquilateralTriangle() { }

        public EquilateralTriangle(double sideLength, double angle)
        {
            SetSideLength(sideLength);
            SetAngle(angle);
        }

        public virtual void SetSideLength(double sideLength)
        {
            if (sideLength <= 0)
                throw new ArgumentException("Введено некоректні дані.");
            SideLength = sideLength;
        }

        public void SetAngle(double angle)
        {
            if (angle != 60)
                throw new ArgumentException("Помилка: Введено некоректні дані.");
            Angle = angle;
        }

        public override string ToString()
        {
            return $"Рівносторонній трикутник: Сторона = {SideLength}, Кут = {Angle}, Периметр = {GetPerimeter():F2}";
        }

        public virtual double GetPerimeter()
        {
            return 3 * SideLength;
        }

        public virtual void Show()
        {
            Console.WriteLine(this);
        }
    }

    class Triangle : EquilateralTriangle
    {
        public double AngleB { get; private set; }
        public double AngleC { get; private set; }

        public Triangle() { }

        public Triangle(double sideA, double angleB, double angleC)
        {
            SetTriangle(sideA, angleB, angleC);
        }

        public void SetTriangle(double sideA, double angleB, double angleC)
        {
            if (angleB <= 0 || angleC <= 0 || angleB + angleC >= 180)
                throw new ArgumentException("Введено некоректні дані.");
            SetSideLength(sideA);
            AngleB = angleB;
            AngleC = angleC;
        }

        public double GetThirdAngle()
        {
            return 180 - AngleB - AngleC;
        }

        public double GetSideB()
        {
            return SideLength * Math.Sin(DegreeToRadian(AngleB)) / Math.Sin(DegreeToRadian(GetThirdAngle()));
        }

        public double GetSideC()
        {
            return SideLength * Math.Sin(DegreeToRadian(AngleC)) / Math.Sin(DegreeToRadian(GetThirdAngle()));
        }

        public override double GetPerimeter()
        {
            return SideLength + GetSideB() + GetSideC();
        }

        public override void Show()
        {
            Console.WriteLine($"Трикутник: Сторона A = {SideLength}, Сторона B = {GetSideB():F2}, Сторона C = {GetSideC():F2}, " +
                              $"Кут A = {GetThirdAngle():F2}, Кут B = {AngleB}, Кут C = {AngleC}, Периметр = {GetPerimeter():F2}");
        }

        private double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var culture = CultureInfo.InvariantCulture;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nОберіть, який трикутник створити:");
                    Console.WriteLine("1 - Рівносторонній трикутник");
                    Console.WriteLine("2 - Звичайний трикутник");
                    Console.WriteLine("0 - Вийти");

                    int userChoose = Convert.ToInt32(Console.ReadLine());

                    EquilateralTriangle triangle;

                    if (userChoose == 1)
                    {
                        Console.WriteLine("Введіть довжину сторони рівностороннього трикутника:");
                        double eqSideLength = double.Parse(Console.ReadLine().Replace(',', '.'), culture);

                        Console.WriteLine("Введіть кут рівностороннього трикутника (має бути 60 градусів):");
                        double angle = double.Parse(Console.ReadLine().Replace(',', '.'), culture);

                        if (angle != 60)
                        {
                            Console.WriteLine("Помилка: Введено некоректні дані.");
                            continue;
                        }

                        triangle = new EquilateralTriangle(eqSideLength, angle);
                    }
                    else if (userChoose == 2)
                    {
                        Console.WriteLine("Введіть довжину сторони трикутника:");
                        double sideA = double.Parse(Console.ReadLine().Replace(',', '.'), culture);

                        Console.WriteLine("Введіть кут B (у градусах):");
                        double angleB = double.Parse(Console.ReadLine().Replace(',', '.'), culture);

                        Console.WriteLine("Введіть кут C (у градусах):");
                        double angleC = double.Parse(Console.ReadLine().Replace(',', '.'), culture);

                        triangle = new Triangle(sideA, angleB, angleC);
                    }
                    else if (userChoose == 0)
                    {
                        Console.WriteLine("Вихід з програми.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Неправильний вибір, спробуйте ще раз.");
                        continue;
                    }

                    triangle.Show();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Введено некоректні дані.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Невідома помилка: {ex.Message}");
                }
            }
        }
    }
}
