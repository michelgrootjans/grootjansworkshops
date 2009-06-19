using System;
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
        string CreateOrFind(string name, string password);
    }

    internal class CharacterService : ICharacterService
    {
        private static readonly List<Character> Characters;
        private static Random rnd;

        static CharacterService()
        {
            Characters = new List<Character>();
            Characters.Add(new Character(1, "Danny the Hun"));
            Characters.Add(new Character(2, "Michel de farmer"));
            rnd = new Random();
        }

        public IEnumerable<ViewCharacterInfoDto> GetAllCharacters()
        {
            return Map.These(Characters).ToAListOf<ViewCharacterInfoDto>();
        }

        public ViewCharacterDto GetCharacter(string characterId)
        {
            var character = Characters.Find(c => c.Id.Equals(characterId.ToLong()));
            return Map.This(character).ToA<ViewCharacterDto>();
        }

        public string CreateOrFind(string name, string password)
        {
            var character = Characters.Find(c => c.Name.Equals(name) && c.Password.Equals(password));
            if (character == null)
            {
                character = new Character(rnd.Next(), name);
                character.SetPassword(password);
                Characters.Add(character);
            }
            return character.Id.ToString();
        }
    }
}