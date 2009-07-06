using Iesi.Collections.Generic;

namespace WarOfWorldcraft.Domain.Entities
{
    public abstract class Character : IStatsHolder
    {
        protected readonly ISet<Item> inventory;

        protected Character() //Necessary for NHibernate
        {
            inventory = new HashedSet<Item>();
        }

        public Character(string name)
        {
            Name = name;
            inventory = new HashedSet<Item>();
        }

        public override string ToString()
        {
            return string.Format("{0} '{1}: {2}/{3};ATK{4};DEF:{5}'",
                                 GetType().Name, Name, HitPoints, MaxHitPoints, Attack, Defence);
        }

        public virtual long Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Level { get; set; }
        public virtual int HitPoints { get; set; }
        public virtual int MaxHitPoints { get; set; }
        public virtual int Attack { get; set; }
        public virtual int Defence { get; set; }
        public virtual int Gold { get; set; }

        public virtual bool IsDead
        {
            get { return HitPoints <= 0; }
        }

        protected internal virtual void AddDamage(int damage)
        {
            if (damage > 0)
                HitPoints -= damage;
            if (HitPoints <= 0)
                HitPoints = 0;
        }
    }
}