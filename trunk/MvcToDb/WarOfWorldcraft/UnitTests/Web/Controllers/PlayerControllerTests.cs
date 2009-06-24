using System;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTests.TestUtilities;
using UnitTests.TestUtilities.Extensions;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Controllers;
using Rhino.Mocks;

namespace UnitTests.Web.Controllers
{
    public class when_PlayerController_is_told_to_show_the_Index 
        : ControllerSpecification<IPlayerController>
    {
        private IPlayerService playerService;

        protected override void Arrange()
        {
            playerService = Dependency<IPlayerService>();
        }

        protected override IPlayerController CreateSystemUnderTest()
        {
            return new PlayerController(playerService);
        }

        protected override Func<IPlayerController, ActionResult> When()
        {
            return c => c.Index();
        }

        [Test]
        public void should_get_all_the_players_in_game_from_the_service()
        {
            playerService.AssertWasCalled(s => s.GetAllPlayers());
        }

        [Test]
        public void should_show_the_index()
        {
            result.ShouldBeOfType<ViewResult>();
        }
    }
}