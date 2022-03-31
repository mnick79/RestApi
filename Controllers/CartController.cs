using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.Validation;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET api/<CartController>/5
        [HttpGet("{customer_number}")]
        public List<Cart> Get(int customer_number)
        {
            GetAllService getAllService = new GetAllService(new Cart());
            return getAllService.GetAll(customer_number: customer_number).Select(x=>(Cart)x).ToList();
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] Cart value)
        {
            PostService postService = new PostService(value);
            CartValidator cartValidator = new CartValidator();
            postService.Post();
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cart value)
        {
            PutService putService = new PutService(value);
            CartValidator cartValidator = new CartValidator();
            putService.Put(id);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteService deleteService = new DeleteService(new DeleteFactory(new Cart()));
            deleteService.Delete(id);
        }
    }
}
