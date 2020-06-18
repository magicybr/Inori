using Inori.Domain.SeedWork;
using System;

namespace Inori.Domain.Infrastructure.Respositories
{
    public class Respository<TKey, TEntity> : IRespository<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : IEntity<TKey>
    {
    }
}
