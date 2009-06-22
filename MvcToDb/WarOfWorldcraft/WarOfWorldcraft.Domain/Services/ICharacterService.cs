using System.Collections.Generic;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Extensions;
using WarOfWorldcraft.Utilities.Mapping;

namespace WarOfWorldcraft.Domain.Services
{
    public interface ICharacterService
    {
        IEnumerable<ViewCharacterInfoDto> GetAllCharacters();
        ViewCharacterDto GetCharacter(string characterId);
        string CreateCharacter(CreateCharacterDto character);
    }

    internal class CharacterService : ServiceBase, ICharacterService
    {
        public IEnumerable<ViewCharacterInfoDto> GetAllCharacters()
        {
            var characters = session.CreateCriteria<Character>().List<Character>();
            return Map.These(characters).ToAListOf<ViewCharacterInfoDto>();
        }

        public ViewCharacterDto GetCharacter(string characterId)
        {
            var character = session.Load<Character>(characterId.ToLong());
            return Map.This(character).ToA<ViewCharacterDto>();
        }

        public string CreateCharacter(CreateCharacterDto characterDto)
        {
            var character = new Character(characterDto.Name);
            character.RandomizeStats();
            session.Save(character);
            return character.Id.ToString();
        }
    }
}