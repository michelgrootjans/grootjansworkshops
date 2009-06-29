using System;
using System.Collections.Generic;
using NHibernate;
using NUnit.Framework;
using UnitTests.TestUtilities;
using Utilities.Mapping;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;
using Rhino.Mocks;
using UnitTests.TestUtilities.Extensions;
using System.Linq;

namespace UnitTests.Domain.Services
{
    public class when_PlayerService_is_told_to_GetAllPlayers : InstanceContextSpecification<IPlayerService>
    {
        private ISession session;
        private IMembershipService membershipService;
        private ICriteria criteria;
        private IEnumerable<ViewPlayerInfoDto> result;
        private IList<Player> players;
        private IMapper<Player, ViewPlayerInfoDto> mapper;
        private Player player;
        private ViewPlayerInfoDto playerDto;

        protected override void Arrange()
        {
            session = CreateSession();
            criteria = Dependency<ICriteria>();
            membershipService = Dependency<IMembershipService>();
            mapper = RegisterMapper<Player, ViewPlayerInfoDto>();
            player = new Player("testplayer", "michel");
            players = new List<Player>{player};
            playerDto = new ViewPlayerInfoDto();

            When(session).IsToldTo(s => s.CreateCriteria<Player>()).Return(criteria);
            When(criteria).IsToldTo(c => c.List<Player>()).Return(players);
            When(mapper).IsToldTo(m => m.Map(player)).Return(playerDto);
        }

        protected override IPlayerService CreateSystemUnderTest()
        {
            return new PlayerService(membershipService);
        }

        protected override void Act()
        {
            result = sut.GetAllPlayers().ToList();
        }

        [Test]
        public void should_get_all_players_from_the_session()
        {
            criteria.AssertWasCalled(c => c.List<Player>());
        }

        [Test]
        public void should_map_the_player_to_a_playerdto()
        {
            result.ShouldContain(playerDto);
        }

    }
}