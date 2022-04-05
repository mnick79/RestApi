using System;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
    public interface IRepoPost<T> : IDisposable where T : IEntity
    {
        void Post(T entity);
    }
}
