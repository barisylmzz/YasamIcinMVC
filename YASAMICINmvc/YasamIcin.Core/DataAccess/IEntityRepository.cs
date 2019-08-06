using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Core.DataAccess
{
    public interface IEntityRepository<TEntity> 
        where TEntity : IEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

    }
}
