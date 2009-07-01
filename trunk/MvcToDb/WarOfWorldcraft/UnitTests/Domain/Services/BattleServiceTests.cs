using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Repository;
using Rhino.Mocks;

namespace UnitTests.Domain.Services
{
    public class when_BattleService_is_told_to_GetAllMonsters : InstanceContextSpecification<IBattleService>
    {
        private IRepository repository;
        private ICriteria criteria;
        private IEnumerable<ViewMonsterInfoDto> result;
        private IInternalPlayerService playerService;
        private IMonsterGenerator monsterGenerator;
        private IList<Monster> monsters;

        protected override void Arrange()
        {
            result = new List<ViewMonsterInfoDto>();
            monsters = new List<Monster>();
            Repeat(() => monsters.Add(new Monster("monster"))).Times(10);

            repository = Dependency<IRepository>();
            criteria = Dependency<ICriteria>();
            playerService = Dependency<IInternalPlayerService>();
            monsterGenerator = Dependency<IMonsterGenerator>();

            When(repository).IsToldTo(r => r.CreateCriteria<Monster>()).Return(criteria);
            When(criteria).IsToldTo(c => c.Add(Arg<ICriterion>.Is.Anything)).Return(criteria);
            When(criteria).IsToldTo(c => c.List<Monster>()).Return(monsters);
        }

        private IRepeatableAction Repeat(Action action)
        {
            return new RepeatableAction(action);   
        }

        protected override IBattleService CreateSystemUnderTest()
        {
            return new BattleService(repository, playerService, monsterGenerator);
        }

        protected override void Act()
        {
            result = sut.GetAllMonsters();
        }

        [Test]
        public void should_get_all_living_monsters()
        {
            criteria.AssertWasCalled(r => r.List<Monster>());
        }
    }
}