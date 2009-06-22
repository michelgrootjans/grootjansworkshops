namespace WarOfWorldcraft.Domain.Entities
{
    public class Player : Character
    {
        public Player() {}
        public Player(string name) : base(name) {}

        public virtual int Gold { get; protected set; }
        public virtual int Experience { get; protected set; }
    }
}