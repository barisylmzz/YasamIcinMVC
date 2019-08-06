using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Core.DataAccess
{
    public class EFRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        TContext ctx;
        public EFRepositoryBase()
        {
            ctx = new TContext();
        }
        public void Add(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            ctx.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            ctx.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return ctx.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return ctx.Set<TEntity>().ToList();
            }
            else
            {
                return ctx.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
