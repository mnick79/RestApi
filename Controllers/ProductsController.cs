﻿using Microsoft.AspNetCore.Mvc;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using RestApi.Domains;
using System.Linq;
using RestApi.Factories.Implimentations;


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
            GetAllService getAllService = new GetAllService(new GetAllFactory(new Product()));
            return getAllService.GetAll().Select(x=>(Product)x).ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            GetOneService getOneService = new GetOneService(new GetOneFactory(new Product()));
            return (Product)getOneService.GetOne(id);
        }
    }
}
