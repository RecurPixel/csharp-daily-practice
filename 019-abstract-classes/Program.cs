// * Create an abstract class `Shape` with an abstract method `CalculateArea()`.
// * Create `Circle` and `Rectangle` classes implementing it.
// * Use a list of shapes and call `CalculateArea()` polymorphically.

// 📝 *Bonus:* Add a common property like `Color` in `Shape`.


abstract class Shape
{
    protected string? Color;
    public abstract double CalculateArea();
    public abstract void ShowDetails();
}

class Circle : Shape
{
    private double Radius { get; set; }
    public Circle(string color, double radious)
    {
        Color = color;
        this.Radius = radious;
    }
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Area of Circle with radious {Radius} is {CalculateArea()} and color is {Color}");
    }
}

class Rectangle : Shape
{
    private double Height { get; set; }
    private double Width { get; set; }
    public Rectangle(string color, double h, double w)
    {
        Color = color;
        this.Height = h;
        this.Width = w;
    }
    public override double CalculateArea()
    {
        return Height * Width;
    }
    public override void ShowDetails()
    {
        Console.WriteLine($"Area of Rectangle with height {Height} and width {Width} is {CalculateArea()} and color is {Color}");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Shape[] shapes = new Shape[5];

        for (int i = 0; i < shapes.Length; i++)
        {
            if (i % 2 == 0)
            {
                shapes[i] = new Circle("red", 7.3 + i);
            }
            else
            {
                shapes[i] = new Rectangle("blue", 3.4 + i, 2.3 + i);
            }

        }
        
        foreach(Shape s in shapes)
        {
            s.ShowDetails();   
        }
    }
}