namespace WarOfWorldcraft.Domain.Entities
{
    public class Player : Character
    {
        protected Player()
        {
        }

        public Player(string name, string account) : base(name)
        {
            Account = account;
        }

        protected virtual string Account { get; set; }
        public virtual int Gold { get; protected set; }
        public virtual int Experience { get; protected set; }

        public virtual void Attack(Character enemy)
        {
            enemy.AddDamage(CalculateDamage(this, enemy));
            AddDamage(CalculateDamage(enemy, this));

            if (enemy.IsDead)
            {
                AddExperienceForKilling(enemy);
                TakeAllGoldFrom(enemy);
            }
        }

        private bool FightHasEndedWith(Character enemy)
        {
            return enemy.IsDead;
        }

        private void AddExperienceForKilling(Character character)
        {
            Experience += character.Level;
        }

        private void TakeAllGoldFrom(Character character)
        {
            Gold += character.Gold;
            character.Gold = 0;
        }

        protected virtual int CalculateDamage(Character attacker, Character defender)
        {
            var attack = attacker.Attack + Roll.SixSidedDice().Once();
            var defense = defender.Defence + Roll.SixSidedDice().Once();
            return attack - defense;
        }
    }
}