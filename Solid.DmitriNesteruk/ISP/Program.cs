using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public class Document
    {

    }

    public interface IMachine {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //Implemented
        }

        public void Print(Document d)
        {
            //Implemented
        }

        public void Scan(Document d)
        {
            //Implemented
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            //Implemented
        }

        public void Fax(Document d)
        {
            //Deixo com a exception? Deixo sem implementar? Retorno Void? Documento para não utilizar esse método??
            //Aí que entra ISP!
        }        

        public void Scan(Document d)
        {
            //Deixo com a exception? Deixo sem implementar? Retorno Void? Documento para não utilizar esse método??
            //Aí que entra ISP!
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
