using System;

class Circle
{
    protected float x0, y0, radius;

    public Circle(float x0, float y0, float radius)
    {
        this.x0 = x0;
        this.y0 = y0;
        this.radius = radius;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Circle center: ({x0}, {y0}), Radius: {radius}");
    }

    public virtual float CalculateMeasure()
    {
        return 2 * (float)Math.PI * radius;
    }
}

class Sphere : Circle
{
    private float z0;

    public Sphere(float x0, float y0, float z0, float radius) : base(x0, y0, radius)
    {
        this.z0 = z0;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Sphere center: ({x0}, {y0}, {z0}), Radius: {radius}");
    }

    public override float CalculateMeasure()
    {
        return 4 * (float)Math.PI * radius * radius;
    }
}

class Program
{
    static void Main()
    {
        Circle[] shapes = new Circle[2];
        shapes[0] = new Circle(0, 0, 5);
        shapes[1] = new Sphere(0, 0, 0, 5);

        foreach (var shape in shapes)
        {
            shape.DisplayInfo();
            Console.WriteLine($"Calculated measure: {shape.CalculateMeasure()}");
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
