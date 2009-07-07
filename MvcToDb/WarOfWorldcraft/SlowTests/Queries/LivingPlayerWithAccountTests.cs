using NUnit.Framework;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Queries;
using UnitTests.TestUtilities.Extensions;

namespace SlowTests.Queries
{
    public class LivingPlatersWithAccountTest : NHibernateTest
    {
        protected override void PrepareData()
        {
            var michel = new Player("michel", "mgr"){HitPoints = 100};
            var tom = new Player("tom", "t") {HitPoints = 0};
            
            repository.Save(michel);
            repository.Save(tom);
        }

        [Test]
        public void should_find_michel()
        {
            repository.Find(new LivingPlayerWithAccount("mgr")).UniqueResult().Name.ShouldBeEqualTo("michel");
        }

        [Test]
        public void should_not_find_tom()
        {
            repository.Find(new LivingPlayerWithAccount("t")).UniqueResult().ShouldBeNull();
        }
    }
}