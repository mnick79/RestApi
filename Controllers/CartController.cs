using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.Validation;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        //[HttpPut("{id}")]
        //public void Put(int id, int customer_id)
        //{
        //    Cart.PutOneCart(id, customer_id);
        //}

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteService deleteService =new DeleteService(new Cart());
            deleteService.Delete(id);
        }
    }
}
