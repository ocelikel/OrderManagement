using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.API.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> filter = null);
    }
}
