namespace OCP_Ajustado
{
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
}
