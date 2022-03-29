using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            GetAllService getAllService = new GetAllService(new Customer());
            return getAllService.GetAll().Select(x=>(Customer)x).ToList();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            GetOneService getOneService = new GetOneService(new Customer());
            return (Customer)getOneService.GetOne(id);
        }

        // POST api/<CustomersController>
       /* [HttpPost]
        public void Post([FromBody] Customer value)
        {
            Customer.NewCustomer(value);
        }
       */

        // PUT api/<CustomersController>/5
       /* [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
       */
       /*
        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer.DeleteCustomer(id);
        }
       */
    }
}
