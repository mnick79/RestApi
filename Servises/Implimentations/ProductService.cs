using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Servises.Implimentations
{
    public class ProductService
    {
        private readonly IRepo<Product> _repo;
        public ProductService(IRepo<Product> repo)
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
