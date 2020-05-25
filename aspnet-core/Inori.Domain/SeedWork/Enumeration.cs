using System;

namespace Inori.Domain.SeedWork
{
    /// <summary>
    /// 实现枚举基类
    /// please refer to https://docs.microsoft.com/zh-cn/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}