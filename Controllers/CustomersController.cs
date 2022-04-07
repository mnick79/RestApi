using Microsoft.AspNetCore.Mvc;
using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Implimentations;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IBaseService<Customer> _baseService;
        public CustomersController(IBaseService<Customer> baseService)
        {
            _baseService=baseService;
        }
        //GET: api/<CustomersController> 
        //[HttpGet]
        //public List<Customer> GetAll()
        //{
        //    CustomerService customerService = new CustomerService(_repo);
        //    return customerService.GetAll(10); //не реализовано из-за задвоения кода
        //}

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _baseService.Get(id);
        }

        // POST api/<CustomersController> -нет в ТЗ
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            Customer customer = value;
            CustomerValidator customerValidator = new CustomerValidator();
            _baseService.Post(customer);
        }


        // PUT api/<CustomersController>/5 -нет в ТЗ
        [HttpPut()]
        public void Put([FromBody] Customer value)
        {
            Customer customer = value;
            CustomerValidator customerValidator = new CustomerValidator();
            _baseService.Put(customer);
        }
        //DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _baseService.Delete(id);
        }
    }
}
