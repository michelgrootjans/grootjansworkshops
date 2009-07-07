using System;
using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Player : Character
    {
        public virtual string Account { get; protected set; }
        public virtual int Experience { get; protected set; }

        protected Player()
        {
        }

        public Player(string name, string account) : base(name)
        {
            Account = account;
            Level = 1;
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
            if (Experience < XP_To_LevelUp) return;

            Level++;
            Attack += Roll.SixSidedDice().Once();
            Defence += Roll.SixSidedDice().Once();
            MaxHitPoints += Roll.SixSidedDice().Once();
            HitPoints = MaxHitPoints;
        }

        private int XP_To_LevelUp
        {
            get
            {
                var level = (Level*2) - 1;
                return level*20;
            }
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

        public virtual void AddGold(int amount)
        {
            Gold += amount;
        }
    }

    public class NullPlayer : Player
    {
    }
}