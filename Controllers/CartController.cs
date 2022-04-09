using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.Validation;
using RestApi.Servises.Interfaces;
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
        public ActionResult<List<Cart>> Get(int customer_number)
        {
            var list = _baseService.GetAll(customer_number);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // POST api/<CartController>
        [HttpPost("{customer_number}")]
        public void Post(int customer_number)
        {
            Cart cart = new Cart() { CustomerNumber = customer_number };
            CartValidator cartValidator = new CartValidator();
            _baseService.Post(cart);
        }

        // PUT api/<CartController>/5
        [HttpPut()]
        public ActionResult Put([FromBody] Cart value)
        {
            Cart cart = value;
            CartValidator cartValidator = new CartValidator();
            if (_baseService.Put(value))
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_baseService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
