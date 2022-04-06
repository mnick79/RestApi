using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.Validation;
using RestApi.Factories.Implimentations;
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
        //[HttpGet("{customer_number}")]
        //public List<NewCart> Get(int customer_number)
        //{
        //    //CartService cartService = new CartService(_repo);
        //    //return (NewCart)cartService.Get(customer_number);
        //    return new List<NewCart>();
        //}

        // POST api/<CartController>
        //[HttpPost]
        //public void Post([FromBody] Cart value)
        //{
        //    Cart cart = value;
        //    PostService postService = new PostService(new PostFactory(cart));
        //    CartValidator cartValidator = new CartValidator();
        //    postService.Post();
        //}

        // PUT api/<CartController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Cart value)
        //{
        //    Cart cart = value;
        //    PutService putService = new PutService(new PutFactory(cart));
        //    CartValidator cartValidator = new CartValidator();
        //    putService.Put(id);
        //}

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CartService cartService = new CartService(_repo);
            cartService.Delete(id);
        }
    }
}
