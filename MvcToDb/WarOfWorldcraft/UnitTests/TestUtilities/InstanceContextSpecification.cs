using System;
using System.Web.Mvc;
using NUnit.Framework;
using Rhino.Mocks;

namespace UnitTests.TestUtilities
{
    [TestFixture]
    public abstract class InstanceContextSpecification<SUT>
    {
        protected SUT sut;

        [SetUp]
        public void SetUp()
        {
            Arrange();
            sut = CreateSystemUnderTest();
            Act();
        }

        protected virtual void Arrange()
        {
        }

        protected virtual SUT CreateSystemUnderTest()
        {
            return default(SUT);
        }

        protected virtual void Act()
        {
        }

        protected T Dependency<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }
    }

    public abstract class ControllerSpecification<SUT> : InstanceContextSpecification<SUT>
    {
        protected ActionResult result;
        protected Func<SUT, ActionResult> when;

        protected override void Arrange()
        {
            base.Arrange();
            when = When();
        }

        protected sealed override void Act()
        {
            result = when(sut);
        }

        protected abstract Func<SUT, ActionResult> When();
    }
}