using System;

namespace WarOfWorldcraft.Domain.Entities
{
    public class Character
    {
        protected Character() {} //Necessary for NHibernate

        public Character(string name)
        {
            Name = name;
            Stats = new Statistics();
        }

        public virtual long Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Gold { get; protected set; }
        public virtual int Experience { get; protected set; }
        public virtual Statistics Stats { get; protected set; }

        protected internal virtual void RandomizeStats()
        {
            Stats.Randomize();
        }
    }
}