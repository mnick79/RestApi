using System;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
    public interface IRepoPut<T> : IDisposable where T : IEntity
    {
        void Put(T entity);
    }
}
