using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Repository;
using Rhino.Mocks;

namespace UnitTests.Domain.Services
{
    public class when_MonsterGenerator_is_told_to_generate_monsters : InstanceContextSpecification<IMonsterGenerator>
    {
        private IRepository repository;
        private IRandomizer randomizer;
        private IMonsterStatsGenerator statsGenerator;
        private IInternalPlayerService playerService;
        private Player player;

        protected override void Arrange()
        {
            player = new Player("michel", "mgr");
            repository = Dependency<IRepository>();
            randomizer = Dependency<IRandomizer>();
            statsGenerator = Dependency<IMonsterStatsGenerator>();
            playerService = Dependency<IInternalPlayerService>();

            When(playerService).IsToldTo(s => s.GetCurrentPlayer()).Return(player);
        }

        protected override IMonsterGenerator CreateSystemUnderTest()
        {
            return new MonsterGenerator(repository, randomizer, statsGenerator, playerService);
        }

        protected override void Act()
        {
            sut.GenerateMonsters();
        }

        [Test]
        public void should_get_the_current_player()
        {
            playerService.AssertWasCalled(s => s.GetCurrentPlayer());
        }

        [Test]
        public void should_save_5_monsters_to_the_repository()
        {
            repository.AssertWasCalled(r => r.Save(Arg<Monster>.Is.Anything), c => c.Repeat.Times(5));
        }
    }
}