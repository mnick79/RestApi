using Microsoft.AspNetCore.Mvc;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;
using RestApi.Models;
using RestApi.Interfaces;
using RestApi.Domains.Validation;
using RestApi.Servises.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseService<Product> _baseService;
        public ProductsController(IBaseService<Product> baseService)
        {
            _baseService = baseService;
        }
        //GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            return _baseService.GetAll(10);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _baseService.Get(id);
        }
        //DELETE api/<ProductsController>/5
        //[HttpDelete("{id}")]              -нет в ТЗ
        //public void Delete(int id)
        //{
        //    _baseService.Delete(id);
        //}
        // POST api/<ProductsController>
        //[HttpPost]
        //public void Post([FromBody] Product value)    - нет в ТЗ
        //{
        //    Product details = value;
        //    ProductValidator detailsValidator = new ProductValidator();
        //    _baseService.Post(details);
        //}
        // PUT api/<ProductsController>/5
        //[HttpPut()]                                   - нет в ТЗ
        //public void Put([FromBody] Product value)
        //{
        //    Product product = value;
        //    ProductValidator cartValidator = new ProductValidator();
        //    _baseService.Put(product);
        //}
    }
}
