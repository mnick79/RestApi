using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Implimentations;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IRepo<Details> _repo;
        
        public DetailsController(IRepo<Details> repo)
        {
            _repo = repo;
            
        }
        // GET api/<DetailsController>/5
        [HttpGet("{cart_number}")]
        public List<Details> Get(int cart_number)
        {
            DetailsService detailsService = new DetailsService(_repo);
            return detailsService.GetAll(cart_number);
        }

        // POST api/<DetailsController>
        [HttpPost]
        public void Post([FromBody] Details value)
        {
            Details details = value;
            DetailsValidator detailsValidator = new DetailsValidator();
            DetailsService detailsService = new DetailsService(_repo);
            detailsService.Post(details);
        }

        // PUT api/<DetailsController>/5
        [HttpPut()]
        public void Put([FromBody] Details value)
        {
            Details details = value;
            DetailsValidator detailsValidator = new DetailsValidator();
            DetailsService detailsService = new DetailsService(_repo);
            detailsService.Put(details);
        }

        //DELETE api/<DetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DetailsService detailsService = new DetailsService(_repo);
            detailsService.Delete(id);
        }

    }
}
