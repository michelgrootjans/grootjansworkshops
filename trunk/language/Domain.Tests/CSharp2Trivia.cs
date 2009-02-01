using System;
using NUnit.Framework;

namespace Domain.Tests
{
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


    }
}