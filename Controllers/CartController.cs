using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IRepo<Cart> _repo;
        public CartController(IRepo<Cart> repo)
        {
            _repo = repo;
        }
        // GET api/<CartController>/5
        [HttpGet("{customer_number}")]
        public List<Cart> Get(int customer_number)
        {
            CartService cartService = new CartService(_repo);
            return cartService.GetAll(customer_number);
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] Cart value)
        {
            Cart cart = value;
            CartValidator cartValidator = new CartValidator();
            CartService cartService = new CartService(_repo);
            cartService.Post(cart);
        }

        // PUT api/<CartController>/5
        [HttpPut()]
        public void Put([FromBody] Cart value)
        {
            Cart cart = value;
            CartValidator cartValidator = new CartValidator();
            CartService cartService = new CartService(_repo);
            cartService.Put(cart);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CartService cartService = new CartService(_repo);
            cartService.Delete(id);
        }
    }
}
