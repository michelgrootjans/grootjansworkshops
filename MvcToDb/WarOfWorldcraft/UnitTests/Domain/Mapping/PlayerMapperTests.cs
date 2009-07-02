using NUnit.Framework;
using UnitTests.TestUtilities;
using Utilities.Mapping;
using WarOfWorldcraft.Domain;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Utilities.Mapping;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Domain.Mapping
{
    public class when_mapping_a_Player_to_a_ViewPlayerInfoDto : InstanceContextSpecification<IMapper<Player, ViewPlayerInfoDto>>
    {
        private Player player;
        private ViewPlayerInfoDto result;

        protected override void Arrange()
        {
            ApplicationStartup.InitializeMappers();
            player = new Player("Michel", "mgr");
            var randomizer = RegisterDependencyInContainer<IRandomizer>();
            When(randomizer).IsToldTo(r => r.GetNumberBetween(1, 6)).Return(6).Repeat.Any();

            new PlayerStatsGenerator().GenerateStatsFor(player);
        }

        protected override IMapper<Player, ViewPlayerInfoDto> CreateSystemUnderTest()
        {
            return new GenericMapper<Player, ViewPlayerInfoDto>();
        }

        protected override void Act()
        {
            result = sut.Map(player);
        }

        [Test]
        public void should_map_its_id()
        {
            result.Id.ShouldBeEqualTo(player.Id.ToString());
        }

        [Test]
        public void should_map_its_name()
        {
            result.Name.ShouldBeEqualTo(player.Name);
        }

        [Test]
        public void should_map_its_experience()
        {
            result.Experience.ShouldBeEqualTo(player.Experience.ToString());
        }

        [Test]
        public void should_map_its_maxhitpoints()
        {
            result.MaxHitPoints.ShouldBeEqualTo(player.MaxHitPoints.ToString());
        }

        [Test]
        public void should_map_its_gold()
        {
            result.Gold.ShouldBeEqualTo(player.Gold.ToString());
        }

    }
}