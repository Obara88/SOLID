namespace OCP_Ajustado
{
    //ISpecification<T> + IFIlter<T> = Specification Pattern
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
