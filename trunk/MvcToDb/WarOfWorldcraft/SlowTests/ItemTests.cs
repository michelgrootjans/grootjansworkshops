using NUnit.Framework;
using UnitTests.TestUtilities.Extensions;
using WarOfWorldcraft.Domain.Entities;

namespace SlowTests
{
    public class ItemCrudTests : NHibernateTest
    {
        private long swordId;
        private string swordName;
        private int price;

        protected override void PrepareData()
        {
            swordName = "rusty sword";
            price = 12;
            var sword = new Item(swordName, price);
            session.Save(sword);
            swordId = sword.Id;
        }

        [Test]
        public void should_be_able_to_get_the_sword()
        {
            var item = session.Load<Item>(swordId);

            item.Name.ShouldBeEqualTo(swordName);
            item.Price.ShouldBeEqualTo(price);
        }
    }

    public class Player_with_items : NHibernateTest
    {
        private long playerId;
        private long swordId;

        protected override void PrepareData()
        {
            var player = new Player("aragorn", "ara");
            player.AddGold(1);
            session.Save(player);
            playerId = player.Id;

            var sword = new Item("rusty sword", 1);
            session.Save(sword);
            swordId = sword.Id;
        }

        [Test]
        public void player_should_be_able_to_buy_the_sword()
        {
            var player = session.Load<Player>(playerId);
            var sword = session.Load<Item>(swordId);

            player.Buy(sword);
            PurgeSession();

            player = session.Load<Player>(playerId);
            player.Inventory.ShouldContain(item => item.Id.Equals(swordId));
        }

        [Test]
        public void session_should_be_able_to_find_the_sword()
        {
            var items = session.CreateQuery("from Item as item where item.Owner is null").List<Item>();
            items.ShouldContain(item => item.Id.Equals(swordId));
        }
    }
}