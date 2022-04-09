using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestApi.Models;
using RestApi.Servises.Interfaces;

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
    }
}
