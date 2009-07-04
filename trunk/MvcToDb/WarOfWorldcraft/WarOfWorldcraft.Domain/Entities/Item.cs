namespace WarOfWorldcraft.Domain.Entities
{
    public class Item
    {
        protected Item() //necessary for NHibernate
        {}

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public virtual long Id { get; protected set; }
        public virtual string Name { get; private set; }
        public virtual int Price { get; private set; }
    }
}