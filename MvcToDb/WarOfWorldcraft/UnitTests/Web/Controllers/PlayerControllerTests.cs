using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTests.TestUtilities;
using UnitTests.TestUtilities.Extensions;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Controllers;

namespace UnitTests.Web.Controllers
{
    public abstract class PlayerControllerTest
        : ControllerSpecification<IPlayerController>
    {
        protected IPlayerService playerService;

        protected override void Arrange()
        {
            playerService = Dependency<IPlayerService>();
        }

        protected override IPlayerController CreateSystemUnderTest()
        {
            return new PlayerController(playerService);
        }
    }

    public class when_PlayerController_is_told_to_show_the_Index
        : PlayerControllerTest
    {
        private IEnumerable<ViewPlayerInfoDto> players;

        protected override void Arrange()
        {
            base.Arrange();
            players = new List<ViewPlayerInfoDto>();
            When(playerService).IsToldTo(s => s.GetAllPlayers<ViewPlayerInfoDto>()).Return(players);
        }

        protected override Func<IPlayerController, ActionResult> When()
        {
            return c => c.Index();
        }

        [Test]
        public void should_get_all_the_players_in_game_from_the_service()
        {
            playerService.AssertWasCalled(s => s.GetAllPlayers<ViewPlayerInfoDto>());
        }

        [Test]
        public void should_show_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

        [Test]
        public void should_put_model_in_the_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeSameAs(players);
        }
    }

    public class when_PlayerController_is_told_to_show_a_player_Detail
        : PlayerControllerTest
    {
        private string playerId;
        private ViewPlayerDto player;

        protected override void Arrange()
        {
            base.Arrange();
            playerId = "8797955";
            player = new ViewPlayerDto();
            When(playerService).IsToldTo(s => s.GetPlayer<ViewPlayerDto>(playerId)).Return(player);
        }

        protected override Func<IPlayerController, ActionResult> When()
        {
            return c => c.Detail(playerId);
        }

        [Test]
        public void should_get_all_the_players_in_game_from_the_service()
        {
            playerService.AssertWasCalled(s => s.GetPlayer<ViewPlayerDto>(playerId));
        }

        [Test]
        public void should_show_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

        [Test]
        public void should_put_model_in_the_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeSameAs(player);
        }
    }

    public class when_PlayerController_is_told_to_show_a_New_player_view
        : PlayerControllerTest
    {
        protected override Func<IPlayerController, ActionResult> When()
        {
            return c => c.New();
        }

        [Test]
        public void should_show_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }
    }

    public class when_PlayerController_is_told_to_Create_a_new_player
        : PlayerControllerTest
    {
        private CreatePlayerDto dto;

        protected override void Arrange()
        {
            base.Arrange();
            dto = new CreatePlayerDto();
            When(playerService).IsToldTo(s => s.CreatePlayer(dto)).Return("34");
        }

        protected override Func<IPlayerController, ActionResult> When()
        {
            return c => c.Create(dto);
        }

        [Test]
        public void should_tell_the_service_to_create_the_user()
        {
            playerService.AssertWasCalled(s => s.CreatePlayer(dto));
        }

        [Test]
        public void should_show_the_new_player_detail()
        {
            result.ShouldBeOfType<RedirectToRouteResult>()
                .ShouldRedirectToController("Player")
                .ShouldRedirectToAction("Detail")
                .ShouldRedirectToId("34");

        }
    }
}