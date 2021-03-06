using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Servises.Interfaces;
using System;
using System.Collections.Generic;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IBaseService<Customer> _baseService;
        public CustomersController(IBaseService<Customer> baseService)
        {
            _baseService = baseService;
        }
        //GET: api/<CustomersController> 
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            var list = _baseService.GetAll(10);
            if (list == null)
            {
                return NotFound("Customers not found");
            }
            return Ok(list);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = _baseService.Get(id);
            if (customer == null)
            {
                return NotFound($"Customer number={id} not found");
            }
            return Ok(customer);
        }
    }
}
