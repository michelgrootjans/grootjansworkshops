using NUnit.Framework;
using UnitTests.TestUtilities;
using Utilities.Mapping;
using WarOfWorldcraft.Domain;
using WarOfWorldcraft.Domain.Dto;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Mapping;
using UnitTests.TestUtilities.Extensions;

namespace UnitTests.Domain.Mapping
{
    public class when_mapping_an_Item_to_a_ViewItemInfoDto : InstanceContextSpecification<IMapper<Item, ViewItemInfoDto>>
    {
        private ViewItemInfoDto result;
        private Item item;

        protected override void Arrange()
        {
            ApplicationStartup.InitializeMappers();
            item = new Item("bread", 45);
        }

        protected override IMapper<Item, ViewItemInfoDto> CreateSystemUnderTest()
        {
            return new GenericMapper<Item, ViewItemInfoDto>();
        }

        protected override void Act()
        {
            result = sut.Map(item);
        }

        [Test]
        public void should_map_its_name()
        {
            result.Name.ShouldBeEqualTo(item.Name);
        }

        [Test]
        public void should_map_its_price()
        {
            result.Price.ShouldBeEqualTo(item.Price.ToString());
        }

    }
}