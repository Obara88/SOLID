using static System.Console;
namespace OCP_Ajustado
{
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
