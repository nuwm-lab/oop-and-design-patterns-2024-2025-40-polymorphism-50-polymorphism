using System;

class SystemOfEquations
{
    public virtual void SetCoefficients(double[,] coeffs, double[] consts) { }
    public virtual void DisplaySystem() { }
    public virtual bool IsSolution(double[] vectorX) { return false; }
}

class SystemOfEquations2x2 : SystemOfEquations
{
    private double[,] coefficients = new double[2, 2];
    private double[] constants = new double[2];

    public override void SetCoefficients(double[,] coeffs, double[] consts)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                coefficients[i, j] = coeffs[i, j];
            }
            constants[i] = consts[i];
        }
    }

    public override void DisplaySystem()
    {
        Console.WriteLine($"{coefficients[0, 0]}*x1 + {coefficients[0, 1]}*x2 = {constants[0]}");
        Console.WriteLine($"{coefficients[1, 0]}*x1 + {coefficients[1, 1]}*x2 = {constants[1]}");
    }

    public override bool IsSolution(double[] vectorX)
    {
        double lhs1 = coefficients[0, 0] * vectorX[0] + coefficients[0, 1] * vectorX[1];
        double lhs2 = coefficients[1, 0] * vectorX[0] + coefficients[1, 1] * vectorX[1];

        return Math.Abs(lhs1 - constants[0]) < 1e-6 && Math.Abs(lhs2 - constants[1]) < 1e-6;
    }
}

class SystemOfEquations3x3 : SystemOfEquations
{
    private double[,] coefficients = new double[3, 3];
    private double[] constants = new double[3];

    public override void SetCoefficients(double[,] coeffs, double[] consts)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                coefficients[i, j] = coeffs[i, j];
            }
            constants[i] = consts[i];
        }
    }

    public override void DisplaySystem()
    {
        Console.WriteLine($"{coefficients[0, 0]}*x1 + {coefficients[0, 1]}*x2 + {coefficients[0, 2]}*x3 = {constants[0]}");
        Console.WriteLine($"{coefficients[1, 0]}*x1 + {coefficients[1, 1]}*x2 + {coefficients[1, 2]}*x3 = {constants[1]}");
        Console.WriteLine($"{coefficients[2, 0]}*x1 + {coefficients[2, 1]}*x2 + {coefficients[2, 2]}*x3 = {constants[2]}");
    }

    public override bool IsSolution(double[] vectorX)
    {
        double lhs1 = coefficients[0, 0] * vectorX[0] + coefficients[0, 1] * vectorX[1] + coefficients[0, 2] * vectorX[2];
        double lhs2 = coefficients[1, 0] * vectorX[0] + coefficients[1, 1] * vectorX[1] + coefficients[1, 2] * vectorX[2];
        double lhs3 = coefficients[2, 0] * vectorX[0] + coefficients[2, 1] * vectorX[1] + coefficients[2, 2] * vectorX[2];

        return Math.Abs(lhs1 - constants[0]) < 1e-6 && Math.Abs(lhs2 - constants[1]) < 1e-6 && Math.Abs(lhs3 - constants[2]) < 1e-6;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose system type: 1 for 2x2, 2 for 3x3");
        char userChoose = Console.ReadKey().KeyChar;
        Console.WriteLine();

        SystemOfEquations system;

        if (userChoose == '1')
        {
            system = new SystemOfEquations2x2();
            double[,] coeffs = { { 1, 2 }, { 3, 4 } };
            double[] consts = { 5, 6 };
            system.SetCoefficients(coeffs, consts);
        }
        else
        {
            system = new SystemOfEquations3x3();
            double[,] coeffs = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double[] consts = { 10, 11, 12 };
            system.SetCoefficients(coeffs, consts);
        }

        system.DisplaySystem();
        double[] solution = (userChoose == '1') ? new double[] { 1, 1 } : new double[] { 1, 1, 1 };
        Console.WriteLine(system.IsSolution(solution) ? "Solution is correct" : "Solution is incorrect");
    }
}