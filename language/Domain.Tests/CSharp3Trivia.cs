using System.Collections.Generic;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class CSharp3Trivia
    {
        // - automatic properties
        public string Name { get; private set; }

        // - implicitly typed local variables
        [Test]
        public void just_checking_what_works_on_implicit_local_variables()
        {
            var a = "Michel";
            //var b;
            //b = 5;

            //Console.WriteLine(a.ToUpper());

            //a = 5;
        }

        // - object initializers
        [Test]
        public void test_object_initializers()
        {
            // Without constructor arguments
            var garfield = new Cat {Name = "Garfield"};
        }

        // - collection initializers
        [Test]
        public void test_collection_initializers()
        {
            var animals = new List<Animal> {new Cat(), new Dog(), new Dragon()};
        }

        // - anonymous types
        [Test]
        public void lets_look_at_a_simple_anonymous_type()
        {
            var michel = new {FirstName = "Michel", LastName = "Grootjans"};
            var danny = new {FirstName = "Danny", LastName = "Gladines"};

            //Console.WriteLine("{0} {1}", michel.FirstName, michel.LastName);
            //Console.WriteLine("{0} {1}", danny.FirstName, danny.LastName);

            //var employees = new[] {michel, danny};
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            //}
        }

        [Test]
        public void lets_look_at_a_list_with_anonymous_types()
        {
            var employees = new[]
                                {
                                    new {FirstName = "Michel", LastName = "Grootjans"},
                                    new {FirstName = "Danny", LastName = "Gladines"}
                                };

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            //}
        }

        [Test]
        public void lets_take_it_one_step_further()
        {
            var cats = new List<Cat>
                           {
                               new Cat {Name = "Garfield", Age = 8},
                               new Cat {Name = "Felix", Age = 50},
                               new Cat {Name = "Tom", Age = 3},
                               new Cat {Name = "Lucifer", Age = 4}
                           };

            //var converted = cats.ConvertAll(a => new {a.Name, IsAdult = (a.Age >= 5)});
            //foreach (var animal in converted)
            //{
            //    Console.WriteLine("Name: {0}, Adult: {1}", animal.Name, animal.IsAdult);
            //}
        }

        //what doesn't work:
        // - var as a return type
        // - var as a field or property
    }
}