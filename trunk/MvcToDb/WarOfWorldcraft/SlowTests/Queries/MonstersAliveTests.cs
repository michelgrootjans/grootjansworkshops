using NUnit.Framework;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Queries;
using UnitTests.TestUtilities.Extensions;

namespace SlowTests.Queries
{
    public class MonstersAliveTest : NHibernateTest
    {
        protected override void PrepareData()
        {
            var deadMonster = new Monster("dead");
            var liveMonster = new Monster("live");
            liveMonster.HitPoints = 100;

            repository.Save(deadMonster);
            repository.Save(liveMonster);
        }

        [Test]
        public void should_find_live_monster()
        {
            repository.Find(new MonstersAlive()).List().ShouldContain(m => m.Name.Equals("live"));
        }

        [Test]
        public void should_not_find_dead_monster()
        {
            repository.Find(new MonstersAlive()).List().ShouldNotContain(m => m.Name.Equals("dead"));
        }
    }
}