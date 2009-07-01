using System;
using NUnit.Framework;
using WarOfWorldcraft.Web;

namespace UnitTests.Web
{
    [TestFixture]
    public class ApplicationTest
    {
        [Test]
        public void should_be_able_to_run_the_global_asax()
        {
            var application = new MvcApplication();
            application.Application_Start();
        }
    }
}