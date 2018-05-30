using System;
namespace SRP_Ajustado
{
    public class PersonDataCapture
    {
        public static Person Capture()
        {
            Person output = new Person();

            Console.Write("What is your first name:");
            output.FirstName = Console.ReadLine();

            Console.Write("What is your last name:");
            output.FirstName = Console.ReadLine();

            return output;
        }
    }
}
