using System;
using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Player : Character
    {
        public virtual string Account { get; protected set; }
        public virtual int Experience { get; protected set; }

        public virtual IEnumerable<Item> Inventory
        {
            get
            {
                foreach (var item in inventory)
                    yield return item;
            }
        }

        protected Player()
        {
        }

        public Player(string name, string account) : base(name)
        {
            Account = account;
        }

        public virtual void Fight(Character enemy)
        {
            enemy.AddDamage(CalculateDamage(this, enemy));

            if (FightHasEndedWith(enemy))
            {
                AddExperienceForKilling(enemy);
                TakeAllGoldFrom(enemy);
            }
            else
            {
                AddDamage(CalculateDamage(enemy, this));
            }
        }

        private bool FightHasEndedWith(Character enemy)
        {
            return enemy.IsDead;
        }

        private void AddExperienceForKilling(IStatsHolder character)
        {
            Experience += character.Level;
            LevelUp();
        }

        private void LevelUp()
        {
            if (Level*10 > Experience) return;

            Level++;
            Attack += Roll.SixSidedDice().Once();
            Defence += Roll.SixSidedDice().Once();
            MaxHitPoints += Roll.SixSidedDice().Once();
            HitPoints = MaxHitPoints;
        }

        private void TakeAllGoldFrom(Character character)
        {
            Gold += character.Gold;
            character.Gold = 0;
        }

        protected virtual int CalculateDamage(Character attacker, Character defender)
        {
            var attack = attacker.Attack + Roll.SixSidedDice().Twice();
            var defense = defender.Defence + Roll.SixSidedDice().Twice();
            return attack - defense;
        }

        public virtual void Buy(Item item)
        {
            if (item.Price > Gold)
                throw new ArgumentException(string.Format("You cannot buy the {0}, you don't have enough gold!",
                                                          item.Name));
            Gold -= item.Price;
            inventory.Add(item);
        }

        public virtual void AddGold(int amount)
        {
            Gold += amount;
        }
    }

    public class NullPlayer : Player
    {
    }
}