using System;
namespace Inori.Domain.SeedWork
{
    public interface IEntity<T> where T : IEquatable<T>
    {
        T Id { get; }
    }
}