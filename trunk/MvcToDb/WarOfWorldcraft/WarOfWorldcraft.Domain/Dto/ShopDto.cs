using System.Collections.Generic;

namespace WarOfWorldcraft.Domain.Dto
{
    public class ViewShopDto
    {
        public IEnumerable<ViewItemInfoDto> Catalog { get; set; }
        public IEnumerable<ViewItemInfoDto> PlayerInventory { get; set; }
    }
}