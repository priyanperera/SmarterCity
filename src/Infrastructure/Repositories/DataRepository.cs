using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext dataContext;

        public DataRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<T> Create<T>(T entity) where T : class
        {
            await Set<T>().AddAsync(entity);
            dataContext.SaveChanges();
            return entity;
        }

        public async Task<T> GetFirst<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        private DbSet<T> Set<T>() where T : class
        {
            return dataContext.Set<T>();
        }
    }
}
