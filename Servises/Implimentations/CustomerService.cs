using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Bases;
using System.Collections.Generic;

namespace RestApi.Servises.Implimentations
{
    public class CustomerService : BaseService<Customer>
    {
        private readonly IRepo<Customer> _repoCustomer;
        public CustomerService(IRepo<Customer> repo) : base(repo)
        {
            _repoCustomer = repo;
        }
        
        //public void Post(Customer customer)
        //{
        //    _repo.Post(customer);
        //}
        //public void Put(Customer customer)
        //{
        //    _repo.Put(customer);
        //}
        
    }
}
