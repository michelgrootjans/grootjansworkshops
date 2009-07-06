using NHibernate;

namespace WarOfWorldcraft.Utilities.Repository
{
    public interface IRepositoryCriteria<T>
    {
        ICriteria AddCriterionTo(ICriteria criteria);
    }
}