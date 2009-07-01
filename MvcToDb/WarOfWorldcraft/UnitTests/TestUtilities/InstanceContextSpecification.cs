using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Utilities.Mapping;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;

namespace UnitTests.TestUtilities
{
    [TestFixture]
    public abstract class StaticContextSpecification
    {
        private IList<object> mappers;

        [SetUp]
        public virtual void SetUp()
        {
            Mapper.Reset();
            Context.Current = new StaticContext();
            mappers = new List<object>();
            PrepareMapper();
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

        private void PrepareMapper()
        {
            Map.Initialize(new StubMapperLocator(mappers));
        }

        protected IMapper<From, To> RegisterMapper<From, To>()
        {
            var mapper = Dependency<IMapper<From, To>>();
            mappers.Add(mapper);
            return mapper;
        }

        protected ISession CreateSession()
        {
            var session = Dependency<ISession>();
            Context.Current.Items[NHibernateHelper.CurrentSessionKey] = session;
            return session;
        }
    }

    public abstract class InstanceContextSpecification<SUT> : StaticContextSpecification
    {
        protected SUT sut;

        [SetUp]
        public override void SetUp()
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

        protected override sealed void Act()
        {
            result = When().Invoke(sut);
        }

        protected abstract Func<SUT, ActionResult> When();
    }

    internal class StubMapperLocator : IMapperLocator
    {
        private readonly IList<object> mappers;

        public StubMapperLocator(IList<object> mappers)
        {
            this.mappers = mappers;
        }

        public IMapper<From, To> GetMapperFor<From, To>()
        {
            foreach (var mapper in mappers)
            {
                if (typeof(IMapper<From, To>).IsAssignableFrom(mapper.GetType()))
                    return (IMapper<From, To>) mapper;
            }
            throw new ArgumentException(string.Format("Could't find a mapper from {0} to {1}", typeof(From), typeof(To)));
        }
    }
}