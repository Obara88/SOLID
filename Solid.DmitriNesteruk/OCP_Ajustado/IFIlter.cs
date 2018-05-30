using System.Collections.Generic;
namespace OCP_Ajustado
{
    public interface IFIlter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}
