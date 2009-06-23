using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IPlayerService
    {
        IEnumerable<ViewPlayerInfoDto> GetAllPlayers();
        ViewPlayerDto GetPlayer(string player);
        string CreatePlayer(CreatePlayerDto player);
    }

    internal class PlayerService : ServiceBase, IPlayerService
    {
        public IEnumerable<ViewPlayerInfoDto> GetAllPlayers()
        {
            var player = session.CreateCriteria<Player>().List<Player>();
            return Map.These(player).ToAListOf<ViewPlayerInfoDto>();
        }

        public ViewPlayerDto GetPlayer(string playerId)
        {
            var player = session.Load<Player>(playerId.ToLong());
            return Map.This(player).ToA<ViewPlayerDto>();
        }

        public string CreatePlayer(CreatePlayerDto playerDto)
        {
            var player = new Player(playerDto.Name);
            player.GenerateStats(new PlayerStatsGenerator());
            session.Save(player);
            return player.Id.ToString();
        }
    }
}