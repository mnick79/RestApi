using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Servises.Implimentations
{
    public class CustomerService
    {
        private readonly IRepo<Customer> _repo;
        public CustomerService(IRepo<Customer> repo)
        {
            _repo=repo;
        }
        public IEntity Get(int number)
        {
            return _repo.Get(number);
        }
        public void Delete(int number)
        {
            if (_repo.IsExist(number))
            {
                _repo.Delete(number);
            }
            else
            {
                throw new System.Exception("500");
            }
        }
        public void Post(Customer customer)
        {
            _repo.Post(customer);
        }
        public void Put(Customer customer)
        {
            _repo.Put(customer);
        }
    }
}
