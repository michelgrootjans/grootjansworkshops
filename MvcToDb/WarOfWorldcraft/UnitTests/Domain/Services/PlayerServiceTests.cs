using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTests.TestUtilities;
using UnitTests.TestUtilities.Extensions;
using Utilities.Mapping;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Repository;

namespace UnitTests.Domain.Services
{
    public abstract class PlayerServiceTest
        : InstanceContextSpecification<IPlayerService>
    {
        protected IMembershipService membershipService;
        protected IRepository repository;
        protected IPlayerStatsGenerator statsGenerator;

        protected override void Arrange()
        {
            repository = Dependency<IRepository>();
            membershipService = Dependency<IMembershipService>();
            statsGenerator = Dependency<IPlayerStatsGenerator>();
        }

        protected override IPlayerService CreateSystemUnderTest()
        {
            return new PlayerService(repository, membershipService, statsGenerator);
        }

        protected Player PlayerWith(string playerName, string account)
        {
            return Arg<Player>.Matches(p => p.Name.Equals(playerName) && p.Account.Equals(account));
        }
    }

    public class when_PlayerService_is_told_to_GetAllPlayers
        : PlayerServiceTest
    {
        private IEnumerable<ViewPlayerInfoDto> result;
        private IList<Player> players;
        private IMapper<Player, ViewPlayerInfoDto> mapper;
        private Player player;
        private ViewPlayerInfoDto playerDto;

        protected override void Arrange()
        {
            base.Arrange();
            mapper = RegisterMapper<Player, ViewPlayerInfoDto>();
            player = new Player("Michel", "MGR");
            players = new List<Player> {player};
            playerDto = new ViewPlayerInfoDto();

            When(repository).IsToldTo(r => r.FindAll<Player>()).Return(players);
            When(mapper).IsToldTo(m => m.Map(player)).Return(playerDto);
        }

        protected override void Act()
        {
            result = sut.GetAllPlayers().ToList();
        }

        [Test]
        public void should_get_all_players_from_the_session()
        {
            repository.AssertWasCalled(r => r.FindAll<Player>());
        }

        [Test]
        public void should_map_the_player_to_a_playerdto()
        {
            mapper.AssertWasCalled(m => m.Map(player));
        }

        [Test]
        public void should_put_the_mapped_dto_in_the_result()
        {
            result.ShouldContain(playerDto);
        }
    }

    public class when_PlayerService_is_told_to_GetPlayer
        : PlayerServiceTest
    {
        private readonly long playerId = 564;
        private Player player;
        private ViewPlayerDto result;
        private ViewPlayerDto playerDto;
        private IMapper<Player, ViewPlayerDto> mapper;

        protected override void Arrange()
        {
            base.Arrange();
            player = new Player("Michel", "MGR");
            playerDto = new ViewPlayerDto();
            mapper = RegisterMapper<Player, ViewPlayerDto>();

            When(repository).IsToldTo(r => r.Load<Player>(playerId)).Return(player);
            When(mapper).IsToldTo(m => m.Map(player)).Return(playerDto);
        }

        protected override void Act()
        {
            result = sut.GetPlayer(playerId.ToString());
        }

        [Test]
        public void should_get_the_player_from_the_repository()
        {
            repository.AssertWasCalled(r => r.Load<Player>(playerId));
        }

        [Test]
        public void should_return_a_player_dto()
        {
            result.ShouldBeSameAs(playerDto);
        }
    }

    public class when_PlayerService_is_told_to_CreatePlayer : PlayerServiceTest
    {
        private string name;
        private CreatePlayerDto createPlayerDto;
        private string playerId;
        private string account;

        protected override void Arrange()
        {
            base.Arrange();
            name = "test name";
            account = "test account";
            createPlayerDto = new CreatePlayerDto {Name = name};

            When(membershipService).IsToldTo(s => s.CurrentAccount).Return(account);
        }

        protected override void Act()
        {
            playerId = sut.CreatePlayer(createPlayerDto);
        }

        [Test]
        public void should_Save_a_new_player_to_the_repository()
        {
            repository.AssertWasCalled(r => r.Save(PlayerWith(name, account)));
        }

        [Test]
        public void should_generate_stats_for_the_player()
        {
            statsGenerator.AssertWasCalled(g => g.GenerateStatsFor(PlayerWith(name, account)));
        }

        [Test]
        public void should_return_a_0_id()
        {
            playerId.ShouldBeEqualTo("0");
        }
    }

    public class when_PlayerService_is_told_to_GetCurrentPlayer
        : InstanceContextSpecification<IInternalPlayerService>
    {
        private IRepository repository;
        private IMembershipService membershipService;
        private IPlayerStatsGenerator statsGenerator;
        private ICriteria criteria;
        private Player player;
        private Player result;

        protected override void Arrange()
        {
            player = new Player("Michel", "mgr");

            repository = Dependency<IRepository>();
            membershipService = Dependency<IMembershipService>();
            statsGenerator = Dependency<IPlayerStatsGenerator>();
            criteria = Dependency<ICriteria>();

            When(membershipService).IsToldTo(s => s.CurrentAccount).Return("mgr");
            When(repository).IsToldTo(r => r.CreateCriteria<Player>()).Return(criteria);
            When(criteria).IsToldTo(c => c.Add(Arg<ICriterion>.Is.Anything)).Return(criteria).Repeat.Any();
            When(criteria).IsToldTo(c => c.UniqueResult<Player>()).Return(player);
        }

        protected override IInternalPlayerService CreateSystemUnderTest()
        {
            return new PlayerService(repository, membershipService, statsGenerator);
        }

        protected override void Act()
        {
            result = sut.GetCurrentPlayer();
        }

        [Test]
        public void should_have_account_criteria()
        {
            var accountCriteria = Arg<SimpleExpression>.Matches(c => c.PropertyName.Equals("Account") && c.Value.Equals("mgr"));
            criteria.AssertWasCalled(c => c.Add(accountCriteria));
        }

        [Test]
        public void should_have_hitpoint_criteria()
        {
            var accountCriteria = Arg<SimpleExpression>.Matches(c => c.PropertyName.Equals("HitPoints") && c.Value.Equals(0));
            criteria.AssertWasCalled(c => c.Add(accountCriteria));
        }

        [Test]
        public void should_get_the_current_player_from_the_repository()
        {
            criteria.AssertWasCalled(r => r.UniqueResult<Player>());
        }

        [Test]
        public void should_return_the_player()
        {
            result.ShouldBeSameAs(player);
        }
    }

    public class when_PlayerService_is_told_to_GetCurrentPlayer_when_player_doesnt_exist
        : InstanceContextSpecification<IInternalPlayerService>
    {
        private IRepository repository;
        private IMembershipService membershipService;
        private IPlayerStatsGenerator statsGenerator;
        private ICriteria criteria;
        private Action getPlayer;

        protected override void Arrange()
        {
            repository = Dependency<IRepository>();
            membershipService = Dependency<IMembershipService>();
            statsGenerator = Dependency<IPlayerStatsGenerator>();
            criteria = Dependency<ICriteria>();

            When(membershipService).IsToldTo(s => s.CurrentAccount).Return("mgr");
            When(repository).IsToldTo(r => r.CreateCriteria<Player>()).Return(criteria);
            When(criteria).IsToldTo(c => c.Add(Arg<ICriterion>.Is.Anything)).Return(criteria).Repeat.Any();
        }

        protected override IInternalPlayerService CreateSystemUnderTest()
        {
            return new PlayerService(repository, membershipService, statsGenerator);
        }

        protected override void Act()
        {
            getPlayer = () => sut.GetCurrentPlayer();
        }

        [Test]
        public void shoul_throw_an_argument_exception()
        {
            getPlayer.ShouldThrowAn<ArgumentException>()
                .Message.ShouldBeEqualTo("You don't have a player.");
        }
    }
}