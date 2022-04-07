using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Implimentations;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;
using System.Linq;
using RestApi.Servises.Interfaces;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IBaseService<Cart> _baseService;
        public CartController(IBaseService<Cart> baseService)
        {
            _baseService = baseService;
        }
        // GET api/<CartController>/5
        [HttpGet("{customer_number}")]
        public List<Cart> Get(int customer_number)
        {
            //CartService cartService = new CartService(_repo);
            //return cartService.GetAll(customer_number);
            return _baseService.GetAll(customer_number);
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] Cart value)
        {
            Cart cart = value;
            CartValidator cartValidator = new CartValidator();
            //CartService cartService = new CartService(_repo);
            //cartService.Post(cart);
            _baseService.Post(cart);
        }

        // PUT api/<CartController>/5
        [HttpPut()]
        public void Put([FromBody] Cart value)
        {
            Cart cart = value;
            CartValidator cartValidator = new CartValidator();
            //CartService cartService = new CartService(_repo);
            //cartService.Put(cart);
            _baseService.Put(cart);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //CartService cartService = new CartService(_repo);
            //cartService.Delete(id);
            _baseService.Delete(id);
        }
    }
}
