using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Domain.Entities
{
    public abstract class Character
    {
        protected Character() {} //Necessary for NHibernate

        public Character(string name)
        {
            Name = name;
            Stats = new Statistics();
        }

        public virtual long Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual Statistics Stats { get; protected set; }

        protected internal virtual void GenerateStats(IStatsGenerator generator)
        {
            Stats.Randomize(generator);
        }
    }
}