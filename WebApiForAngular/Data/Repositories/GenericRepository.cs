using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiForAngular.Data.IRepositories;

namespace WebApiForAngular.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DotnetandAngularDbContext _dbContext;
        private readonly DbSet<T> _dbSet;   
        public GenericRepository(DotnetandAngularDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet= _dbContext.Set<T>();
        }
        public async ValueTask<T> CreateAsync(T entity)
            =>(await _dbSet.AddAsync(entity)).Entity;
        

        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);

            if (entity != null)
            {
                _dbSet.Remove(entity);

                return true;
            }
            return false;
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
        {
           IQueryable<T> query = expression is null ? _dbSet : _dbSet.Where(expression);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    if (!string.IsNullOrEmpty(include))
                        query = query.Include(include);
                }


                if (!isTracking)
                    query = query.AsNoTracking();
            }
            return query;
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
            =>(await GetAllAsync(expression, includes,false).FirstOrDefaultAsync());
        

        public T Update(T entity)=>
             _dbSet.Update(entity).Entity;
        

        public async ValueTask SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
