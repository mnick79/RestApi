using Microsoft.AspNetCore.Mvc;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using RestApi.Domains;
using System.Linq;
using RestApi.Domains.Validation;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            GetAllService getAllService = new GetAllService(new Product());
            return getAllService.GetAll().Select(x=>(Product)x).ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            GetOneService getOneService = new GetOneService(new Product());
            return (Product)getOneService.GetOne(id);
        }

        // POST api/<ProductsController>
          [HttpPost]
           public void Post([FromBody] Product value)
           {
            PostService postService = new PostService(value);
            ProductValidator productValidator = new ProductValidator();
            postService.Post();
           }

        /*    // PUT api/<ProductsController>/5
           [HttpPut("{id}")]
           public void Put(int id, [FromBody] string value)
           {
           }

           // DELETE api/<ProductsController>/5
           [HttpDelete("{id}")]
           public void Delete(int id)
           {
           }
        */
    }
}
