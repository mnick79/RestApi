using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.Validation;
using RestApi.Servises.Implimentations;
using RestApi.Servises.Interfaces;
using System;
using System.Collections.Generic;

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
            return _baseService.GetAll(customer_number);
        }

        // POST api/<CartController>
        [HttpPost("{customer_number}")]
        public void Post(int customer_number)
        {
            Cart cart = new Cart() { CustomerNumber=customer_number};
            CartValidator cartValidator = new CartValidator();
            _baseService.Post(cart);
        }

        // PUT api/<CartController>/5
        [HttpPut()]
        public void Put([FromBody] Cart value)
        {
            Cart cart = value;
            CartValidator cartValidator = new CartValidator();
            _baseService.Put(value);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _baseService.Delete(id);
        }
    }
}
