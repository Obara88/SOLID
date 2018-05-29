using System;
using System.Collections.Generic;
using static System.Console;
namespace OCP
{

    public enum Size { Small, Medium, Large, Yuge }
    public enum Color { Red, Green, Blue }

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

    public class ProductFilter //Should be possible to extend this class...should...
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }

        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

    }

    //ISpecification<T> + IFIlter<T> = Specification Pattern
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFIlter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return color == t.Color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size Size)
        {
            this.size = Size;
        }

        public bool IsSatisfied(Product t)
        {
            return size == t.Size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first;
        private ISpecification<T> second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(nameof(first));
            this.second = second ?? throw new ArgumentNullException(nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    public class BetterFillter : IFIlter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }                
            }
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
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                WriteLine($" - {p.Name} is green");
            }

            var bf = new BetterFillter();
            WriteLine("Green products (new): ");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - {p.Name} is green");
            }


            WriteLine("Large blue Items");
            foreach (var p in bf.Filter(products, 
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue), 
                    new SizeSpecification(Size.Large)
                )))
            {
                WriteLine($" - {p.Name} is blue");
            }
        }
    }
}
