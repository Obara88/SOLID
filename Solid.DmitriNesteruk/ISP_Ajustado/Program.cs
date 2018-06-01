 namespace ISP_Ajustado
{
    public class Document { }    

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter //...
    {

    }

    public class MultiFunctionMachin : IMultiFunctionDevice
    {
        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    public class OldFashionedPrinter : IPrinter
    {
        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
