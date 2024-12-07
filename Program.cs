using System;

// Абстрактний клас для систем лінійних рівнянь
class SystemOfEquations
{
    // Метод для задання коефіцієнтів і вільних членів
    public virtual void SetCoefficients(double[,] coeffs, double[] consts) { }

    // Метод для відображення системи рівнянь
    public virtual void DisplaySystem() { }

    // Метод для перевірки, чи є вектор розв'язком
    public virtual bool IsSolution(double[] vectorX) { return false; }
}

// Клас для роботи із системою 2x2
class SystemOfEquations2x2 : SystemOfEquations
{
    // Матриця коефіцієнтів
    private double[,] coefficients = new double[2, 2];

    // Вектор вільних членів
    private double[] constants = new double[2];

    // Перевизначення методу для задання коефіцієнтів
    public override void SetCoefficients(double[,] coeffs, double[] consts)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                coefficients[i, j] = coeffs[i, j]; // Копіюємо коефіцієнти
            }
            constants[i] = consts[i]; // Копіюємо вільні члени
        }
    }

    // Перевизначення методу для відображення системи
    public override void DisplaySystem()
    {
        Console.WriteLine($"{coefficients[0, 0]}*x1 + {coefficients[0, 1]}*x2 = {constants[0]}");
        Console.WriteLine($"{coefficients[1, 0]}*x1 + {coefficients[1, 1]}*x2 = {constants[1]}");
    }

    // Перевизначення методу для перевірки розв'язку
    public override bool IsSolution(double[] vectorX)
    {
        // Рахуємо ліву частину рівнянь для введеного вектора
        double lhs1 = coefficients[0, 0] * vectorX[0] + coefficients[0, 1] * vectorX[1];
        double lhs2 = coefficients[1, 0] * vectorX[0] + coefficients[1, 1] * vectorX[1];

        // Перевіряємо, чи співпадають обчислені значення з вільними членами
        return Math.Abs(lhs1 - constants[0]) < 1e-6 && Math.Abs(lhs2 - constants[1]) < 1e-6;
    }
}

// Клас для роботи із системою 3x3
class SystemOfEquations3x3 : SystemOfEquations
{
    // Матриця коефіцієнтів
    private double[,] coefficients = new double[3, 3];

    // Вектор вільних членів
    private double[] constants = new double[3];

    // Перевизначення методу для задання коефіцієнтів
    public override void SetCoefficients(double[,] coeffs, double[] consts)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                coefficients[i, j] = coeffs[i, j]; // Копіюємо коефіцієнти
            }
            constants[i] = consts[i]; // Копіюємо вільні члени
        }
    }

    // Перевизначення методу для відображення системи
    public override void DisplaySystem()
    {
        Console.WriteLine($"{coefficients[0, 0]}*x1 + {coefficients[0, 1]}*x2 + {coefficients[0, 2]}*x3 = {constants[0]}");
        Console.WriteLine($"{coefficients[1, 0]}*x1 + {coefficients[1, 1]}*x2 + {coefficients[1, 2]}*x3 = {constants[1]}");
        Console.WriteLine($"{coefficients[2, 0]}*x1 + {coefficients[2, 1]}*x2 + {coefficients[2, 2]}*x3 = {constants[2]}");
    }

    // Перевизначення методу для перевірки розв'язку
    public override bool IsSolution(double[] vectorX)
    {
        // Рахуємо ліву частину рівнянь для введеного вектора
        double lhs1 = coefficients[0, 0] * vectorX[0] + coefficients[0, 1] * vectorX[1] + coefficients[0, 2] * vectorX[2];
        double lhs2 = coefficients[1, 0] * vectorX[0] + coefficients[1, 1] * vectorX[1] + coefficients[1, 2] * vectorX[2];
        double lhs3 = coefficients[2, 0] * vectorX[0] + coefficients[2, 1] * vectorX[1] + coefficients[2, 2] * vectorX[2];

        // Перевіряємо, чи співпадають обчислені значення з вільними членами
        return Math.Abs(lhs1 - constants[0]) < 1e-6 && Math.Abs(lhs2 - constants[1]) < 1e-6 && Math.Abs(lhs3 - constants[2]) < 1e-6;
    }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        // Вибір типу системи
        Console.WriteLine("Choose system type: 1 for 2x2, 2 for 3x3 ");
        char userChoose = Console.ReadKey().KeyChar;
        Console.WriteLine();

        SystemOfEquations system;

        // Ініціалізація системи залежно від вибору користувача
        if (userChoose == '1')
        {
            system = new SystemOfEquations2x2();

            // Задаємо приклад коефіцієнтів для 2x2
            double[,] coeffs = { { 1, 2 }, { 3, 4 } };
            double[] consts = { 5, 6 };
            system.SetCoefficients(coeffs, consts);
        }
        else
        {
            system = new SystemOfEquations3x3();

            // Задаємо приклад коефіцієнтів для 3x3
            double[,] coeffs = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double[] consts = { 10, 11, 12 };
            system.SetCoefficients(coeffs, consts);
        }

        // Відображення системи
        system.DisplaySystem();

        // Задаємо вектор для перевірки розв'язку
        double[] solution = (userChoose == '1') ? new double[] { 1, 1 } : new double[] { 1, 1, 1 };

        // Виводимо результат перевірки
        Console.WriteLine(system.IsSolution(solution) ? "Solution is correct" : "Solution is incorrect");
    }
}

