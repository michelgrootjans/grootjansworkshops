using AutoMapper;
using WarOfWorldcraft.Domain.Dto;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Mapping;

namespace WarOfWorldcraft.Domain
{
    public static class ApplicationStartup
    {
        public static void Run()
        {
            InitializeMappers();
        }

        internal static void InitializeMappers()
        {
            Mapper.CreateMap<long, string>().ConvertUsing(l => l.ToString());
            Mapper.CreateMap<Player, ViewPlayerInfoDto>();
            Mapper.CreateMap<Player, ViewPlayerDto>()
                .ForMember(dto => dto.PercentHitPoints, config => config.MapFrom(player => player.HitPoints*100/player.MaxHitPoints));

            Mapper.CreateMap<Monster, ViewMonsterInfoDto>();
            Mapper.CreateMap<Monster, ViewMonsterDto>();

            Mapper.AssertConfigurationIsValid();

            Map.Initialize(new GenericMapperLocator());
        }
    }
}