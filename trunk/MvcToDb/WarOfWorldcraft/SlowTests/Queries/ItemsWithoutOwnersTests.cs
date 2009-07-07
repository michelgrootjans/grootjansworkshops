using System.Linq;
using NUnit.Framework;
using UnitTests.TestUtilities.Extensions;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Queries;

namespace SlowTests.Queries
{
    public class ItemsWithoutOwnersTests : NHibernateTest
    {
        protected override void PrepareData()
        {
            var michel = new Player("michel", "mgr");
            michel.Buy(new Item("knife", 0));
            repository.Save(michel);
            repository.Save(new Item("sword", 4));
        }

        [Test]
        public void should_have_at_least_2_items_in_repository()
        {
            repository.FindAll<Item>().Count().ShouldBeEqualTo(2);
        }

        [Test]
        public void should_find_sword()
        {
            repository.Find(new ItemsWithoutOwner()).List().ShouldContain(i => i.Name.Equals("sword"));
        }

        [Test]
        public void should_not_find_knife()
        {
            repository.Find(new ItemsWithoutOwner()).List().ShouldNotContain(i => i.Name.Equals("knife"));
        }
    }
}