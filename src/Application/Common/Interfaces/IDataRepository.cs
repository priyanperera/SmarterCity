using System.Linq.Expressions;

namespace Application.Common.Interfaces
{
    public interface IDataRepository
    {
        Task<T> GetFirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> Create<T>(T entity) where T : class;
        IQueryable<T> Query<T>() where T : class;
    }
}
