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
        public ActionResult<List<Product>> Get()
        {
            List<Product> list = _baseService.GetAll(10);
            if (list == null)
            {
                return NotFound("Products not found");
            }
            return Ok(list);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = _baseService.Get(id);
            if (product == null)
            {
                return NotFound($"Product number={id} not found");
            }
            return Ok(product);
        }
    }
}
