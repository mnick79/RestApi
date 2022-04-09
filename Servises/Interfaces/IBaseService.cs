using RestApi.Interfaces;
using System.Collections.Generic;

namespace RestApi.Servises.Interfaces
{
    public interface IBaseService<T> where T : IEntity
    {
        public bool Delete(int id);
        public void Post(T entity);
        public bool Put(T entity);
        public T Get(int id);
        public List<T> GetAll(int limit);
    }
}
