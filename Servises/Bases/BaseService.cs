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
        public virtual bool Delete(int id)
        {
            if (_repo.IsExist(id))
            {
                _repo.Delete(id);
                return true;
            }
            return false;
        }
        public virtual void Post(T entity)
        {
            _repo.Post(entity);
        }
        public virtual bool Put(T entity)
        {
            if (!_repo.IsExist(entity.Number))
            {
                _repo.Put(entity);
                return true;
            }
            return false;
            
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
