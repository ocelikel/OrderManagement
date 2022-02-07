using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.API.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity:class
    {
        private readonly OrderContext _orderContext;
        public Repository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

      

        public async Task Delete(TEntity entity)
        {
            _orderContext.Set<TEntity>().Remove(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _orderContext.Set<TEntity>().Add(entity);

            await _orderContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            EntityEntry updatedEntity = _orderContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;

            foreach (var propertyName in updatedEntity.Properties)
            {
                if (updatedEntity.Property(propertyName.Metadata.Name).CurrentValue == null)
                    updatedEntity.Property(propertyName.Metadata.Name).IsModified = false;
            }
           

            await _orderContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                          ? _orderContext.Set<TEntity>()
                          : _orderContext.Set<TEntity>().Where(filter);
        }
    }
}
