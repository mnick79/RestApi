using System.Collections.Generic;

namespace RestApi.Interfaces
{
    public interface IRepo<T> where T : IEntity
    {
        void Delete(int number);
        bool IsExist(int number);
        T Get(int number);

        List<T> GetAll(T entity);

        void Post(T entity);
        void Put(T entity);


    }
}
