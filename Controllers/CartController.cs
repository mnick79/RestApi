using Microsoft.AspNetCore.Mvc;
using RestApi.Items;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/<CartController>
        [HttpGet]
        public List<Cart> Get()
        {
            return Cart.GetAllCart("select * from cart;");
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return Cart.GetOneCart(id);
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cart.DeleteOneCart(id);
        }
    }
}
