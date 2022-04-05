using System;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
    public interface IRepoGetOne<T> : IDisposable where T : IEntity
    {
        T GetOne(int number);

    }
}
