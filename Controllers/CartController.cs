using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Models.Validation;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
                return NotFound($"Carts for customer number ={customer_number} not found");
            }
            return Ok(list);
        }

        // POST api/<CartController>
        [HttpPost]
        public ActionResult Post([FromBody] Cart value)
        {
            Cart cart = value;
            if (cart.Number == 0 && new[] { "", "string" }.Contains(cart.Description.Trim()) && cart.TotalPrice == 0)
            {
                _baseService.Post(cart);
                return Ok();
            }
            return BadRequest("Number, TotalPrice and Description are not used");

        }

        // PUT api/<CartController>/5
        [HttpPut()]
        public ActionResult Put([FromBody] Cart value)
        {
            if (value.Number == 0 || value.TotalPrice == 0 || (new[] { "", "string" }.Contains(value.Description.Trim())))
            {
                return BadRequest("Number, TotalPrice and Description must have other values");
            }
            if (_baseService.Put(value))
            {
                return Ok();
            }
            return NotFound($"Cart number = {value.Number} not found");
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_baseService.Delete(id))
            {
                return Ok();
            }
            return BadRequest($"Cart number ={id}not found");
        }
    }
}
