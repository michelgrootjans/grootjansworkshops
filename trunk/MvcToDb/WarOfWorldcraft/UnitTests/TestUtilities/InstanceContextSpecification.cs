using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Utilities.Mapping;
using WarOfWorldcraft.Utilities.IoC;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Repository;

namespace UnitTests.TestUtilities
{
    [TestFixture]
    public abstract class StaticContextSpecification
    {
        private IList<object> mappers;
        private Dictionary<Type, object> container;

        [SetUp]
        public virtual void SetUp()
        {
            Context.Current = new StaticContext();
            InitMappers();
            InitContainer();
            Arrange();
        }

        private void InitMappers()
        {
            Mapper.Reset();
            mappers = new List<object>();
            Map.Initialize(new StubMapperLocator(mappers));
        }

        private void InitContainer()
        {
            container = new Dictionary<Type, object>();
            Container.Initialize(new InMemoryContainer(container));
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

        protected IRepeatableAction Repeat(Action action)
        {
            return new RepeatableAction(action);
        }

        protected T RegisterDependencyInContainer<T>() where T : class
        {
            var dependency = Dependency<T>();
            container.Add(typeof(T), dependency);
            return dependency;
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
}