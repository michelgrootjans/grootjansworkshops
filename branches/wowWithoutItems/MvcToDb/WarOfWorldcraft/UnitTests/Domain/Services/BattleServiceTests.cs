using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTests.TestUtilities;
using UnitTests.TestUtilities.Extensions;
using Utilities.Mapping;
using WarOfWorldcraft.Domain.Dto;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Queries;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Repository;

namespace UnitTests.Domain.Services
{
    public class BattleServiceTest : InstanceContextSpecification<IBattleService>
    {
        protected IRepository repository;
        protected IInternalPlayerService playerService;

        protected override void Arrange()
        {
            repository = Dependency<IRepository>();
            playerService = Dependency<IInternalPlayerService>();
        }

        protected override sealed IBattleService CreateSystemUnderTest()
        {
            return new BattleService(repository, playerService);
        }
    }

    public class BatlleService_GetAllMonsters_Test
        : BattleServiceTest
    {
        protected IEnumerable<ViewMonsterInfoDto> result;
        protected IList<Monster> monstersFromRepository;
        protected int numberOfMonstersInRepository;
        protected IMapper<Monster, ViewMonsterInfoDto> monsterMapper;

        protected override void Arrange()
        {
            base.Arrange();
            result = new List<ViewMonsterInfoDto>();
            monstersFromRepository = new List<Monster>();
            Repeat(() => monstersFromRepository.Add(new Monster("monster")))
                .Times(numberOfMonstersInRepository);

            monsterMapper = RegisterMapper<Monster, ViewMonsterInfoDto>();

            var iRepositoryResult = Dependency<IRepositoryResult<Monster>>();
            When(repository).IsToldTo(r => r.Find(Arg<MonstersAlive>.Is.Anything)).Return(iRepositoryResult);
            When(iRepositoryResult).IsToldTo(c => c.List()).Return(monstersFromRepository);
        }

        protected override void Act()
        {
            result = sut.GetAllMonsters<ViewMonsterInfoDto>().ToList();
        }
    }

    public class when_BattleService_is_told_to_GetAllMonsters_with_enough_monsters_in_db :
        BatlleService_GetAllMonsters_Test
    {
        protected override void Arrange()
        {
            numberOfMonstersInRepository = 5;
            base.Arrange();
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

    public class when_BattleService_is_told_to_Challenge_a_monster
        : BattleServiceTest
    {
        private ViewChallengeDto<ViewPlayerDto, ViewMonsterDto> result;
        private readonly long monsterId = 6541846;
        private Player player;
        private IMapper<Player, ViewPlayerDto> playerMapper;
        private IMapper<Monster, ViewMonsterDto> monsterMapper;
        private Monster monster;
        private ViewMonsterDto monsterDto;
        private ViewPlayerDto playerDto;

        protected override void Arrange()
        {
            base.Arrange();
            player = new Player("Michel", "mgr");
            playerDto = new ViewPlayerDto();
            monster = new Monster("Horrible monster");
            monsterDto = new ViewMonsterDto();

            playerMapper = RegisterMapper<Player, ViewPlayerDto>();
            monsterMapper = RegisterMapper<Monster, ViewMonsterDto>();

            When(playerService).IsToldTo(p => p.GetCurrentPlayer()).Return(player);
            When(repository).IsToldTo(r => r.Load<Monster>(monsterId)).Return(monster);
            When(playerMapper).IsToldTo(m => m.Map(player)).Return(playerDto);
            When(monsterMapper).IsToldTo(m => m.Map(monster)).Return(monsterDto);
        }

        protected override void Act()
        {
            result = sut.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId.ToString());
        }

        [Test]
        public void should_get_the_current_player()
        {
            playerService.AssertWasCalled(s => s.GetCurrentPlayer());
        }

        [Test]
        public void should_map_the_player()
        {
            playerMapper.AssertWasCalled(m => m.Map(player));
        }

        [Test]
        public void should_get_the_monster_from_the_repository()
        {
            repository.AssertWasCalled(r => r.Load<Monster>(monsterId));
        }

        [Test]
        public void should_map_the_monster()
        {
            monsterMapper.AssertWasCalled(m => m.Map(monster));
        }

        [Test]
        public void should_return_both_mapped_objects()
        {
            result.Monster.ShouldBeSameAs(monsterDto);
            result.Player.ShouldBeSameAs(playerDto);
        }
    }

    public class when_BattleService_is_told_to_Attack_a_monster
        : BattleServiceTest
    {
        private readonly long monsterId = 654132;
        private Player player;
        private Monster monster;

        protected override void Arrange()
        {
            base.Arrange();
            player = new Player("Michel", "mgr");
            monster = new Monster("Horrible monster");
            RegisterDependencyInContainer<IRandomizer>();
            When(playerService).IsToldTo(s => s.GetCurrentPlayer()).Return(player);
            When(repository).IsToldTo(r => r.Load<Monster>(monsterId)).Return(monster);
        }

        protected override void Act()
        {
            sut.Attack(monsterId.ToString());
        }

        [Test]
        public void should_get_the_current_player()
        {
            playerService.AssertWasCalled(s => s.GetCurrentPlayer());
        }

        [Test]
        public void should_get_the_monster_from_the_repository()
        {
            repository.AssertWasCalled(r => r.Load<Monster>(monsterId));
        }
    }
}