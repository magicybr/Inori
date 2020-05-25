using System;
namespace Inori.Domain.SeedWork
{
    public class Entity<T> : IEntity<T>
        where T : IEquatable<T>
    {
        public T Id { get; set; }
    }
}