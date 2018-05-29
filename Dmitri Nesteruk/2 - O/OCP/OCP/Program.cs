using System;
using System.Collections.Generic;
using static System.Console;
namespace OCP
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }


    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var House = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, House };

            var pf = new ProductFilter();
            WriteLine("Green products (old): ");
            foreach(var p in pf.FilterByColor(products, Color.Green))
            {
                WriteLine($" - {p.Name } is green");
            }

            //A classe filtro deveria ser abertar para extensão...
            //Vamos refatorar!
        }
    }
}
