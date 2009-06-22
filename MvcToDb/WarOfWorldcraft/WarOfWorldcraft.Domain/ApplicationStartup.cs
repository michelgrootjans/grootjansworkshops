using AutoMapper;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Domain.Services;

namespace WarOfWorldcraft.Domain
{
    public class ApplicationStartup
    {
        public static void Run()
        {
            InitializeMappers();
        }

        private static void InitializeMappers()
        {
            Mapper.CreateMap<long, string>().ConvertUsing(l => l.ToString());
            Mapper.CreateMap<Player, ViewPlayerInfoDto>();
            Mapper.CreateMap<Player, ViewPlayerDto>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}