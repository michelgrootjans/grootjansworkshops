using System;
using Domain.Extensions;
using NUnit.Framework;

namespace Domain.Tests.ExtensionTests
{
    [TestFixture]
    public class TimeSpanExtensionTests
    {
        [Test]
        public void Test8HoursAgo()
        {
            var eightHours = TimeSpan.FromHours(8);
            Assert.AreEqual(DateTime.Now.AddHours(-8), eightHours.Ago());
        }

        [Test]
        public void Test8HoursAgo2()
        {
            Assert.AreEqual(DateTime.Now.AddHours(-8), 8.Hours().Ago());
        }

        [Test]
        public void Test8HoursFromNow()
        {
            Assert.AreEqual(DateTime.Now.AddHours(8), 8.Hours().FromNow());
        }

    }
}