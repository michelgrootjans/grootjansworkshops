using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IPlayerService
    {
        IEnumerable<ViewPlayerInfoDto> GetAllCharacters();
        ViewPlayerDto GetPlayer(string characterId);
        string CreateCharacter(CreatePlayerDto player);
    }

    internal class PlayerService : ServiceBase, IPlayerService
    {
        public IEnumerable<ViewPlayerInfoDto> GetAllCharacters()
        {
            var player = session.CreateCriteria<Player>().List<Player>();
            return Map.These(player).ToAListOf<ViewPlayerInfoDto>();
        }

        public ViewPlayerDto GetPlayer(string characterId)
        {
            var player = session.Load<Player>(characterId.ToLong());
            return Map.This(player).ToA<ViewPlayerDto>();
        }

        public string CreateCharacter(CreatePlayerDto playerDto)
        {
            var character = new Player(playerDto.Name);
            character.GenerateStats(new PlayerStatsGenerator());
            session.Save(character);
            return character.Id.ToString();
        }
    }
}