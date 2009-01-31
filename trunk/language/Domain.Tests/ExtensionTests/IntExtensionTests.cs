using System;
using Domain.Extensions;
using NUnit.Framework;

namespace Domain.Tests.ExtensionTests
{
    [TestFixture]
    public class IntExtensionTests
    {
        [Test]
        public void TestHours()
        {
            Assert.AreEqual(TimeSpan.FromHours(8), 8.Hours());
        }

        [Test]
        public void TestMinutes()
        {
            Assert.AreEqual(TimeSpan.FromMinutes(8), 8.Minutes());
        }

    }
}