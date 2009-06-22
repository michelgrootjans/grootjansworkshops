using System;
using System.Collections.Generic;
using System.Threading;
using NHibernate.Criterion;
using WarOfWorldcraft.Domain.Entities;
using WarOfWorldcraft.Utilities.Mapping;
using WarOfWorldcraft.Utilities.Extensions;

namespace WarOfWorldcraft.Domain.Services
{
    public interface IBattleService
    {
        IEnumerable<ViewMonsterInfoDto> GetAllMonsters();
        ViewChallengeDto Challenge(string monsterId);
    }

    internal class BattleService : ServiceBase, IBattleService
    {
        public IEnumerable<ViewMonsterInfoDto> GetAllMonsters()
        {
            yield return new ViewMonsterInfoDto{Id="1", Name = "Horrible troll", StatsMaxHitPoints = "10"};
            yield return new ViewMonsterInfoDto{Id="2", Name = "Bah", StatsMaxHitPoints = "12"};
        }

        public ViewChallengeDto Challenge(string monsterId)
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;
            var player = session.CreateCriteria<Character>().Add(Restrictions.Eq("User", userName)).List();
            var monster = session.Load<Monster>(monsterId.ToLong());

            var challenge = new ViewChallengeDto();
            challenge.Player = Map.This(player).ToA<ViewPlayerDto>();
            challenge.Monster = Map.This(monster).ToA<ViewMonsterDto>();

            return challenge;
        }
    }
}