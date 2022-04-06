using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Domains.Validation;
using RestApi.Factories.Implimentations;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepo<Customer> _repo;
        public CustomersController(IRepo<Customer> repo)
        {
            _repo=repo;
        }
        //GET: api/<CustomersController> 
        [HttpGet]
        public List<Customer> Get()
        {
            CustomerService customerService = new CustomerService(_repo);
            return customerService.GetAll(10); //не реализовано из-за задвоения кода
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            CustomerService oneService = new CustomerService(_repo);
            return (Customer)oneService.Get(id);

        }

        // POST api/<CustomersController> -нет в ТЗ
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            CustomerService customerService = new CustomerService(_repo);
            CustomerValidator customerValidator = new CustomerValidator();
            customerService.Post(value);
        }


        // PUT api/<CustomersController>/5 -нет в ТЗ
        [HttpPut()]
        public void Put([FromBody] Customer value)
        {
            Customer customer = value;
            CustomerValidator customerValidator = new CustomerValidator();
            CustomerService customerService = new CustomerService(_repo);
            customerService.Put(customer);
        }
        //DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerService customerService = new CustomerService(_repo);
            customerService.Delete(id);
        }
    }
}
