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
        public ActionResult<List<Details>> Get(int cart_number)
        {
            List<Details> list = _baseService.GetAll(cart_number);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
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
        public ActionResult Delete(int id)
        {
            if (_baseService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
