using System;
using System.Web.Mvc;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace UnitTests.TestUtilities
{
    [TestFixture]
    public abstract class StaticContextSpecification
    {
        [SetUp]
        public virtual void SetUp()
        {
            Arrange();
        }

        protected virtual void Arrange()
        {
        }

        protected T Dependency<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }

        protected IStubSpecification<Target> When<Target>(Target target) where Target : class
        {
            return new StubSpecification<Target>(target);
        }
    }

    public abstract class InstanceContextSpecification<SUT> : StaticContextSpecification
    {
        protected SUT sut;

        [SetUp]
        public virtual void SetUp()
        {
            base.SetUp();
            sut = CreateSystemUnderTest();
            Act();
        }

        protected virtual SUT CreateSystemUnderTest()
        {
            return default(SUT);
        }

        protected virtual void Act()
        {
        }
    }

    internal class StubSpecification<Target> : IStubSpecification<Target> where Target : class
    {
        private readonly Target target;

        public StubSpecification(Target target)
        {
            this.target = target;
        }

        public IMethodOptions<Result> IsToldTo<Result>(Function<Target, Result> function)
        {
            return target.Stub(function);
        }
    }

    public interface IStubSpecification<Target>
    {
        IMethodOptions<Result> IsToldTo<Result>(Function<Target, Result> function);
    }

    public abstract class ControllerSpecification<SUT> : 
        InstanceContextSpecification<SUT> where SUT : class
    {
        protected ActionResult result;

        protected sealed override void Act()
        {
            result = When().Invoke(sut);
        }

        protected abstract Func<SUT, ActionResult> When();
    }
}