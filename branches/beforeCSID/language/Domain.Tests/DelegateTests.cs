using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class DelegateTests
    {
        [Test]
        public void Lets_have_a_simple_test()
        {
            var script = new BuildScript();
            script.Run("compile", "test");
        }
    }
}