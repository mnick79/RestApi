using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // GET: api/<CartController>
        //[HttpGet]
        //public List<Cart> Get()
        //{
        //    return Cart.GetAllCart("select * from cart limit 10;");
        //}

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            GetOneService getOneService = new GetOneService(new Cart());
            return (Cart)getOneService.GetOne(id);
        }

        // POST api/<CartController>
        //[HttpPost]
        //public void Post([FromBody] Cart value)
        //{
        //    Cart.PostCart(value);
        //}

        // PUT api/<CartController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, int customer_id)
        //{
        //    Cart.PutOneCart(id, customer_id);
        //}

        // DELETE api/<CartController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    Cart.DeleteOneCart(id);
        //}
    }
}
