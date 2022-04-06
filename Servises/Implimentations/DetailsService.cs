using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Servises.Implimentations
{
    public class DetailsService
    {
        private readonly IRepo<Details> _repo;
        public DetailsService(IRepo<Details> repo)
        {
            _repo = repo;
        }
        public IEntity Get(int number)
        {
            return _repo.Get(number);
        }
        public void Delete(int number)
        {
            _repo.Delete(number);
        }
    }
}
