using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
namespace Inori.Domain.SeedWork
{
    public interface IRespository<TEntity> where TEntity : Entity
    {
        Entity Add(TEntity item);

        void Update(TEntity item);

        Task<TEntity> Find(int Id);

        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);
        
        Task<IEnumerable<TEntity>> FindAll(CancellationToken token = default);

        Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);
    }
}