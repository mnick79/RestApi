using System;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
    public interface IRepoGetAll<T> : IDisposable where T : IEntity
    {
        List<T> GetAll();
    }
}
