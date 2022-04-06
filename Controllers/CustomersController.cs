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
       //[HttpGet]
       // public List<NewCustomer> Get()
       // {


       //     GetAllService getAllService = new GetAllService(new NewCustomer());
       //     return getAllService.GetAll().Select(x => (newCustomer)x).ToList();
       // }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            CustomerService oneService = new CustomerService(_repo);
            return (Customer)oneService.Get(id);

        }

        // POST api/<CustomersController> -нет в ТЗ
        //[HttpPost]
        //public void Post([FromBody] Customer value)
        //{
        //    PostService postService = new PostService(value);
        //    CustomerValidator customerValidator = new CustomerValidator();
        //    postService.Post();
        //}


        // PUT api/<CustomersController>/5 -нет в ТЗ
        //[HttpPut("{id}")]
        // public void Put(int id, [FromBody] Customer value)
        // {
        //    PutService putService = new PutService(value);
        //    CustomerValidator customerValidator = new CustomerValidator();
        //    putService.Put(id);

        // }
        //DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerService customerService = new CustomerService(_repo);
            customerService.Delete(id);
        }
    }
}
