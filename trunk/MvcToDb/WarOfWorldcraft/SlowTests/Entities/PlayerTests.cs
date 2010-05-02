using NUnit.Framework;
using UnitTests.TestUtilities.Extensions;
using WarOfWorldcraft.Domain.Entities;

namespace SlowTests.Entities
{
    public class PlayerCrudTest : NHibernateTest
    {
        private long playerId;
        private string playerName;
        private string account;

        protected override void PrepareData()
        {
            playerName = "Michel";
            account = "grm";
            var player = new Player(playerName, account);
            session.Save(player);
            playerId = player.Id;
        }

        [Test]
        public void should_be_able_to_get_the_player()
        {
            var player = session.Load<Player>(playerId);
            player.Name.ShouldBeEqualTo(playerName);
            player.Account.ShouldBeEqualTo(account);
        }

        [Test]
        public void should_be_able_to_update_the_player()
        {
            var player = session.Load<Player>(playerId);
            player.Gold.ShouldBeEqualTo(0);
            player.AddGold(100);
            PurgeSession();

            player = session.Load<Player>(playerId);
            player.Gold.ShouldBeEqualTo(100);
        }

        [Test]
        public void should_be_able_to_delete_a_player()
        {
            var player = session.Load<Player>(playerId);
            session.Delete(player);
            PurgeSession();

            session.Get<Player>(playerId).ShouldBeNull();
        }

        [Test]
        public void should_find_player_by_querying_the_whole_database()
        {
            var player = session.Load<Player>(playerId);
            var objects = session.CreateCriteria<object>().List<object>();
            objects.Contains(player).ShouldBeTrue();
        }

    }

    public class PlayerInventoryTest : NHibernateTest
    {
        private long playerId;

        protected override void PrepareData()
        {
            var player = new Player("Michel", "mgr");
            session.Save(player);
            player.AddGold(100);
            player.Buy(new Item("Gizmo", 10));
            playerId = player.Id;
        }

        [Test]
        public void should_be_able_to_get_the_players_inventory()
        {
            var player = session.Load<Player>(playerId);
            player.Inventory.ShouldContain(i => i.Name.Equals("Gizmo"));
            player.Gold.ShouldBeEqualTo(90);
        }
    }
}