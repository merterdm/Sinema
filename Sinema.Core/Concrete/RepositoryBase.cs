using Sinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Sinema.Core.Concrete
{
    public class RepositoryBase<T,TContext> : IRepositoryBase<T,TContext> where T : class, new() where TContext:DbContext ,new()
    {
        public TContext dbContext { get; set; }

        public RepositoryBase()
        {


            dbContext = new TContext();
        }

        public virtual async Task<int> CreateAsync(T entity)
        {
            //işi yapmasini asenkron olarak bildiriyoruz
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }
        public virtual async Task<T?> GetByIdAsync(string id)
        {
            return await dbContext.Set<T>().FindAsync(Guid.Parse(id));

        }

        public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
            else
                return await dbContext.Set<T>().FirstOrDefaultAsync();

        }

        //public virtual async Task<ICollection<T>> RawSqlQuery(T entity, string sql)
        //{
        //    var result = dbContext.Set<T>().Rwa(sql);

        //    return await result.ToListAsync();
        //}

        public virtual async Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).ToListAsync();
            else
                return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] include)
        {
            var query = dbContext.Set<T>();
            if (filter != null)
            {
                query.Where(filter);
            }
            var result = include.Aggregate(query.AsQueryable(),
                                    (current, includeprop) => current.Include(includeprop));
            return result;
        }







    }
}
