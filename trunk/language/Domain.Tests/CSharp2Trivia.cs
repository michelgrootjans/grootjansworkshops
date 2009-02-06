using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class MyClass
{
}

namespace Domain.Tests
{
    public class MyClass
    {
    }

    [TestFixture]
    public class CSharp2Trivia
    {
        [Test]
        public void test_the_null_coalescing_operator()
        {
            var michel = new Person("Michel", new DateTime(1988, 12, 9));
            var albert = new Person("Albert Einstein", new DateTime(1879, 3, 14), new DateTime(1955, 4, 18));

            Console.WriteLine("Name: {0}, Age: {1}", michel.Name, michel.Age);
            Console.WriteLine("Name: {0}, Age: {1}", albert.Name, albert.Age);
        }

        [Test]
        public void I_would_like_to_reach_internals()
        {
            var michel = new Person("Michel", new DateTime(1988, 12, 9));
            Console.WriteLine(michel.DateOfBirth);
            // DateOfBirth is internal, but is available to this assembly
            // because of the property [assembly: InternalsVisibleTo("Domain.Tests")]
        }

        [Test]
        public void I_would_like_to_reach_a_class_that_has_no_namespace()
        {
            var myClass1 = new MyClass();
            var myClass2 = new global::MyClass();
            var myClass3 = new global::Domain.Tests.MyClass();
            Console.WriteLine(myClass1);
            Console.WriteLine(myClass2);
            Console.WriteLine(myClass3);
        }

        [Test]
        public void covariance_and_contravariance()
        {
            //List<Person> people = new List<Employee>();

            List<Person> list1 = new List<Employee>().ConvertAll(e => e as Person);

            //alternatief met LINQ
            IEnumerable<Person> list2 = new List<Employee>().Cast<Person>();
            IList<Person> list3 = new List<Employee>().Cast<Person>().ToList();
        }
    }
}