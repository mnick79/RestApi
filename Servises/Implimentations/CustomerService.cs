using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Bases;
using System.Collections.Generic;
using FluentValidation;

namespace RestApi.Servises.Implimentations
{
    public class CustomerService : BaseService<Customer>
    {
        private readonly IRepo<Customer> _repoCustomer;
        public CustomerService(IRepo<Customer> repo) : base(repo)
        {
            _repoCustomer = repo;
        }
        public override void Delete(int id)
        {
            if (_repoCustomer.IsExist(id))
            {
                CustomerValidator validator = new CustomerValidator();
            }
            base.Delete(id);
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
