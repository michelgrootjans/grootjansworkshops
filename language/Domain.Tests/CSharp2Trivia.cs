using System;
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
            //Console.WriteLine(michel.DateOfBirth);
        }

        [Test]
        public void I_would_like_to_readch_a_class_that_has_no_namespace()
        {
            var myClass = new MyClass();
            Console.WriteLine(myClass);
        }

        [Test]
        public void covariance_and_contravariance()
        {
            //List<Person> people = new List<Employee>();
        }
    }
}