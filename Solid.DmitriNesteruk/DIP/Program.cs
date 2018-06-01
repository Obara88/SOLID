using System.Collections.Generic;
using System.Linq;
using static System.Console;
namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }

    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public string Name;
    }

    //low-level
    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        //Criamos essa prop somente para Research acessar ela, criou-se uma dependencia de tal
        //forma que se quisermos alterar como Relationships armazena os dados, Research sofrerá impacto
        public List<(Person, Relationship, Person)> Relations => relations;

    }

    //High-level
    public class Research
    {
        public Research(Relationships relationships)
        {
            var relations = relationships.Relations; // <<--- low-level part
            foreach (var r in relations.Where(
                x => x.Item1.Name == "John" &&
                    x.Item2 == Relationship.Parent
                ))
            {
                WriteLine($"John has a chiled called { r.Item3.Name}");
            }
        }       
    }
}
