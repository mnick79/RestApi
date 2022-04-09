using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;


namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IBaseService<Details> _baseService;
        
        public DetailsController(IBaseService<Details> baseService)
        {
            _baseService = baseService;
            
        }
        // GET api/<DetailsController>/5
        [HttpGet("{cart_number}")]
        public List<Details> Get(int cart_number)
        {
            return _baseService.GetAll(cart_number);
        }

        // POST api/<DetailsController>
        [HttpPost]
        public void Post([FromBody] Details value)
        {
            _baseService.Post(value);
        }

        // PUT api/<DetailsController>/5
        [HttpPut()]
        public void Put([FromBody] Details value)
        {
            _baseService.Put(value);
        }

        //DELETE api/<DetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _baseService.Delete(id);
        }

    }
}
