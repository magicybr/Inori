using System;
namespace Inori.Domain.SeedWork
{
    public interface IRespository<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : IEntity<TKey>
    {

    }
}