using System.Reflection.Metadata.Ecma335;
using System.Linq;

abstract class Shape // Cannot create new shape()
{
    public abstract double Area(); // // every shape MUST calculate its own area
    public virtual string Describe()
    {
        return $"{GetType().Name} - Area: {Area():F2}"; // Display the name and area of the shape
    }
}

class Circle : Shape  // derived class (child)
{
    public int radius { get; set; }
    public override double Area() //override is how a child class replaces the parent's version of a method.
    {
        return Math.PI * radius * radius;
    }

}

class Rectangle : Shape  // derived class (child)
{
    public int width { get; set; }
    public int height { get; set; }
    public override double Area() 
    { 
        return width * height; 
    }

}

class Triangle : Shape  // derived class (child)
{
    public int _base { get; set; }
    public int height { get; set; }
    public override double Area()
    {
        return 0.5 * _base * height;
    }

}




class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Rectangle { width = 5 , height = 3 }, // adding shape values
            new Circle { radius = 3 }, 
            new Triangle { _base = 2 , height = 5 }
        };


        static void PrintReport(List<Shape> shapes) //PrintReport() takes a list of shapes and prints each one.
                                                    //It works for any shape type because they all inherit from Shape
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Describe()); 
            }
        }

        PrintReport(shapes);


        //lamda expression s=>s.Area() where s is a variable
        var largest = shapes.Max(s => s.Area()); //for each s, gives you s.Area() - Max() for largest area, can us Min() for minimum 
        Console.WriteLine($"\nLargest area: {largest:F2} ");
    }
}

