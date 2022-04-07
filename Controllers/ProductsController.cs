using Microsoft.AspNetCore.Mvc;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;
using RestApi.Models;
using RestApi.Interfaces;
using RestApi.Domains.Validation;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepo<Product> _repo;
        public ProductsController(IRepo<Product> repo)
        {
            _repo = repo;
        }
        //GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            ProductService productService = new ProductService(_repo);
            return productService.GetAll(10); //не реализовано из-за задвоения кода
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            ProductService oneService = new ProductService(_repo);
            return (Product)oneService.Get(id);
        }
        //DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductService productService = new ProductService(_repo);
            productService.Delete(id);
        }
        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            Product details = value;
            ProductValidator detailsValidator = new ProductValidator();
            ProductService productService = new ProductService(_repo);
            productService.Post(details);
        }
        // PUT api/<ProductsController>/5
        [HttpPut()]
        public void Put([FromBody] Product value)
        {
            Product cart = value;
            ProductValidator cartValidator = new ProductValidator();
            ProductService productService = new ProductService(_repo);
            productService.Put(cart);
        }
    }
}
