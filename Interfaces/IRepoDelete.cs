using System;
using System.Collections.Generic;

namespace RestApi.Interfaces
{
    public interface IRepoDelete<T> where T : IEntity
    {
        void Delete(int number);

    }
}
