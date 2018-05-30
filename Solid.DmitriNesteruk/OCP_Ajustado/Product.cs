using System;
namespace OCP_Ajustado
{
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
}
