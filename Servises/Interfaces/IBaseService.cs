using RestApi.Interfaces;
using System.Collections.Generic;

namespace RestApi.Servises.Interfaces
{
    public interface IBaseService<T> where T : IEntity
    {
        public void Delete(int id);
        public void Post(T entity);
        public void Put(T entity);
        public T Get(int id);
        public List<T> GetAll(int limit);
    }
}
