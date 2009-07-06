using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Dto;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Controllers;
using Rhino.Mocks;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Web.Controllers
{
    public abstract class BattleControllerTest : ControllerSpecification<IBattleController>
    {
        protected IBattleService battleService;

        protected override void Arrange()
        {
            base.Arrange();
            battleService = Dependency<IBattleService>();
        }

        protected override IBattleController CreateSystemUnderTest()
        {
            return new BattleController(battleService);
        }
    }

    public class when_BattleController_is_told_to_show_its_Index
        : BattleControllerTest
    {
        private List<ViewMonsterInfoDto> monsters;

        protected override void Arrange()
        {
            base.Arrange();
            monsters = new List<ViewMonsterInfoDto>();
            When(battleService).IsToldTo(s => s.GetAllMonsters<ViewMonsterInfoDto>()).Return(monsters);
        }

        protected override Func<IBattleController, ActionResult> When()
        {
            return c => c.Index();
        }

        [Test]
        public void should_get_all_monsters()
        {
            battleService.AssertWasCalled(s => s.GetAllMonsters<ViewMonsterInfoDto>());   
        }

        [Test]
        public void should_return_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

        [Test]
        public void should_put_the_result_in_the_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeSameAs(monsters);
        }
    }

    public class when_BattleController_is_told_to_Challenge_a_monster
        : BattleControllerTest
    {
        private string monsterId = "654";
        private ViewChallengeDto<ViewPlayerDto, ViewMonsterDto> challenge;

        protected override void Arrange()
        {
            base.Arrange();
            challenge = new ViewChallengeDto<ViewPlayerDto, ViewMonsterDto>();
            When(battleService).IsToldTo(s => s.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId)).Return(challenge);
        }

        protected override Func<IBattleController, ActionResult> When()
        {
            return c => c.Challenge(monsterId);
        }

        [Test]
        public void should_tell_the_service_to_get_the_challenge()
        {
            battleService.AssertWasCalled(s => s.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId));
        }

        [Test]
        public void should_return_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEmpty();
        }

        [Test]
        public void should_put_the_challenge_in_the_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeSameAs(challenge);
        }
    }


    public class when_BattleController_is_told_to_Challenge_a_monster_and_player_wins
        : BattleControllerTest
    {
        private string monsterId = "654";
        private ViewChallengeDto<ViewPlayerDto, ViewMonsterDto> challenge;

        protected override void Arrange()
        {
            base.Arrange();
            challenge = new ViewChallengeDto<ViewPlayerDto, ViewMonsterDto> { Monster = new ViewMonsterDto() { IsDead = true } };
            When(battleService).IsToldTo(s => s.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId)).Return(challenge);
        }

        protected override Func<IBattleController, ActionResult> When()
        {
            return c => c.Challenge(monsterId);
        }

        [Test]
        public void should_tell_the_service_to_get_the_challenge()
        {
            battleService.AssertWasCalled(s => s.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId));
        }

        [Test]
        public void should_return_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEqualTo("Win");
        }

        [Test]
        public void should_put_the_challenge_in_the_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeSameAs(challenge);
        }
    }


    public class when_BattleController_is_told_to_Challenge_a_monster_and_monster_wins
        : BattleControllerTest
    {
        private string monsterId = "654";
        private ViewChallengeDto<ViewPlayerDto, ViewMonsterDto> challenge;

        protected override void Arrange()
        {
            base.Arrange();
            challenge = new ViewChallengeDto<ViewPlayerDto, ViewMonsterDto> { Player = new ViewPlayerDto() { IsDead = true } };
            When(battleService).IsToldTo(s => s.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId)).Return(challenge);
        }

        protected override Func<IBattleController, ActionResult> When()
        {
            return c => c.Challenge(monsterId);
        }

        [Test]
        public void should_tell_the_service_to_get_the_challenge()
        {
            battleService.AssertWasCalled(s => s.Challenge<ViewPlayerDto, ViewMonsterDto>(monsterId));
        }

        [Test]
        public void should_return_the_default_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewName.ShouldBeEqualTo("Dead");
        }

        [Test]
        public void should_put_the_challenge_in_the_view()
        {
            result.ShouldBeOfType<ViewResult>()
                .ViewData.Model.ShouldBeSameAs(challenge);
        }
    }

    public class when_BattleController_is_told_to_attack_a_monster 
        : BattleControllerTest
    {
        private string monsterId = "54";

        protected override Func<IBattleController, ActionResult> When()
        {
            return c => c.Attack(monsterId);
        }

        [Test]
        public void should_temm_the_battleservice_to_attack_the_monster()
        {
            battleService.AssertWasCalled(s => s.Attack(monsterId));
        }

        [Test]
        public void should_redirect_to_the_challenge_screen()
        {
            result.ShouldBeOfType<RedirectToRouteResult>()
                .ShouldRedirectToController("Battle")
                .ShouldRedirectToAction("Challenge")
                .ShouldRedirectToId(monsterId);
        }

    }

}