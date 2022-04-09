using RestApi.Interfaces;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;

namespace RestApi.Servises.Bases
{
    public class BaseService<T> : IBaseService<T> where T : IEntity
    {
        private readonly IRepo<T> _repo;
        protected const decimal discont = 0.9m;
        public BaseService(IRepo<T> repo)
        {
            _repo = repo;
        }
        public virtual void Delete(int id)
        {
            _repo.Delete(id);
        }
        public virtual void Post(T entity)
        {
            _repo.Post(entity);
        }
        public virtual void Put(T entity)
        {
            _repo.Put(entity);
        }
        public virtual T Get(int id)
        {
            return _repo.Get(id);
        }
        public virtual List<T> GetAll(int limit)
        {
            return _repo.GetAll(limit);
        }
    }
}
