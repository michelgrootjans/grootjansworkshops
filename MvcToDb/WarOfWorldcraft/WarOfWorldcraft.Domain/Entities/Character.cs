namespace WarOfWorldcraft.Domain.Entities
{
    internal class Character
    {
        public Character(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        internal string Password { get; private set; }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}