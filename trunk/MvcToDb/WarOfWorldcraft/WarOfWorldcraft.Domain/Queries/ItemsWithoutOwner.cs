using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Repository;

namespace WarOfWorldcraft.Domain.Queries
{
    public class ItemsWithoutOwner : IRepositoryQuery<Item>
    {
        //from Item as item where item.Owner is null
        public string QueryString
        {
            get { return "from Item as item where item.Owner is null"; }
        }
    }
}