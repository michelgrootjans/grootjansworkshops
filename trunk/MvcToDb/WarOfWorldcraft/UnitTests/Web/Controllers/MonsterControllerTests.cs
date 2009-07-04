using System;
using System.Web.Mvc;
using NUnit.Framework;
using Rhino.Mocks;
using UnitTests.TestUtilities;
using WarOfWorldcraft.Domain.Services;
using WarOfWorldcraft.Web.Controllers;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Web.Controllers
{
    public class when_MonsterController_is_told_to_generate_monsters : ControllerSpecification<IMonsterController>
    {
        private IMonsterGenerator monsterGenerator;

        protected override void Arrange()
        {
            base.Arrange();
            monsterGenerator = Dependency<IMonsterGenerator>();

        }

        protected override IMonsterController CreateSystemUnderTest()
        {
            return new MonsterController(monsterGenerator);
        }

        protected override Func<IMonsterController, ActionResult> When()
        {
            return c => c.Generate();
        }

        [Test]
        public void should_tell_the_service_to_generate_monsters()
        {
            monsterGenerator.AssertWasCalled(g => g.GenerateMonsters());
        }

        [Test]
        public void should_redirect_to_arena()
        {
            result.ShouldBeOfType<RedirectToRouteResult>()
                .ShouldRedirectToController("Battle")
                .ShouldRedirectToAction("Index");
        }
    }
}