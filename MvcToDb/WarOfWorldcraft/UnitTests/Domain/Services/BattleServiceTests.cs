using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using UnitTests.TestUtilities;
using Utilities.Mapping;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Repository;
using Rhino.Mocks;
using System.Linq;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Domain.Services
{
    public class BatlleService_GetAllMonsters_Test 
        : InstanceContextSpecification<IBattleService>
    {
        protected IRepository repository;
        protected ICriteria criteria;
        protected IEnumerable<ViewMonsterInfoDto> result;
        protected IInternalPlayerService playerService;
        protected IMonsterGenerator monsterGenerator;
        protected IList<Monster> monstersFromRepository;
        protected int numberOfMonstersInRepository;
        protected IMapper<Monster, ViewMonsterInfoDto> monsterMapper;

        protected override void Arrange()
        {
            result = new List<ViewMonsterInfoDto>();
            monstersFromRepository = new List<Monster>();
            Repeat(() => monstersFromRepository.Add(new Monster("monster")))
                .Times(numberOfMonstersInRepository);

            repository = Dependency<IRepository>();
            criteria = Dependency<ICriteria>();
            playerService = Dependency<IInternalPlayerService>();
            monsterGenerator = Dependency<IMonsterGenerator>();
            monsterMapper = RegisterMapper<Monster, ViewMonsterInfoDto>();

            When(repository).IsToldTo(r => r.CreateCriteria<Monster>()).Return(criteria);
            When(criteria).IsToldTo(c => c.Add(Arg<ICriterion>.Is.Anything)).Return(criteria);
            When(criteria).IsToldTo(c => c.List<Monster>()).Return(monstersFromRepository);
        }

        protected override IBattleService CreateSystemUnderTest()
        {
            return new BattleService(repository, playerService, monsterGenerator);
        }

        protected override void Act()
        {
            result = sut.GetAllMonsters().ToList();
        }
    }

    public class when_BattleService_is_told_to_GetAllMonsters_with_enough_monsters_in_db : BatlleService_GetAllMonsters_Test
    {
        protected override void Arrange()
        {
            numberOfMonstersInRepository = 5;
            base.Arrange();
        }

        [Test]
        public void should_get_all_living_monsters()
        {
            criteria.AssertWasCalled(r => r.List<Monster>());
        }

        [Test]
        public void should_return_a_list_of_5_monsters()
        {
            result.Count().ShouldBeEqualTo(5);
        }

        [Test]
        public void should_map_all_the_monsters()
        {
            foreach (var monster in monstersFromRepository)
                monsterMapper.AssertWasCalled(m => m.Map(monster));
        }
    }

    public class when_BattleService_is_told_to_GetAllMonsters_with_insufficient_monsters_in_db 
        : BatlleService_GetAllMonsters_Test
    {
        private Player player;
        private int playerLevel;
        private IList<Monster> generatedMonsters;
        private Monster casper;

        protected override void Arrange()
        {
            numberOfMonstersInRepository = 0;
            base.Arrange();

            playerLevel = 54;
            player = new Player("Michel", "mgr"){Level = playerLevel};
            casper = new Monster("Casper");
            generatedMonsters = new List<Monster> { casper };

            When(playerService).IsToldTo(s => s.GetCurrentPlayer()).Return(player);
            When(monsterGenerator).IsToldTo(g => g.GenerateMonstersAroundLevel(playerLevel)).Return(generatedMonsters);
        }

        [Test]
        public void should_get_all_living_monsters()
        {
            criteria.AssertWasCalled(r => r.List<Monster>());
        }

        [Test]
        public void should_save_the_new_monsters_to_the_repository()
        {
            repository.AssertWasCalled(r => r.Save(casper));
        }

        [Test]
        public void should_map_all_the_monsters()
        {
            monsterMapper.AssertWasCalled(m => m.Map(casper));
            foreach (var monster in monstersFromRepository)
                monsterMapper.AssertWasCalled(m => m.Map(monster));
        }

        [Test]
        public void should_return_the_mapped_monsters()
        {

        }
    }
}