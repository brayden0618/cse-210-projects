using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>
        {
            new Circle("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Square("Green", 3)
        };

            foreach (Shape s  in shapes)
            {
                Console.WriteLine($"Shape Color: {s.GetColor()}");
                Console.WriteLine($"Shape Area: {s.GetArea()}");
            }
        }
    }