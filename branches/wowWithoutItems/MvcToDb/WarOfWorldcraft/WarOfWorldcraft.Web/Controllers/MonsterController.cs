using System.Web.Mvc;
using MvcContrib.Filters;
using WarOfWorldcraft.Domain.Services;
using MvcContrib;

namespace WarOfWorldcraft.Web.Controllers
{
    public interface IMonsterController
    {
        ActionResult Generate();
    }

    [Rescue("Error")]
    public class MonsterController : Controller, IMonsterController
    {
        private readonly IMonsterGenerator monsterGenerator;

        public MonsterController(IMonsterGenerator monsterGenerator)
        {
            this.monsterGenerator = monsterGenerator;
        }

        public ActionResult Generate()
        {
            monsterGenerator.GenerateMonsters();
            return this.RedirectToAction<BattleController>(c => c.Index());
        }
    }
}