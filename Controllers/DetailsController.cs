using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
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
        // GET api/<DetailsController>/5
        [HttpGet("{cart_number}")]
        public List<Details> Get(int cart_number)
        {
            GetAllService getAllService = new GetAllService(new Details());
            return getAllService.GetAll(cart_number: cart_number).Select(x=>(Details)x).ToList();
        }

        // POST api/<DetailsController>
        //[HttpPost]
        //public void Post([FromBody] Details value)
        //{
        //    Details.PostDetails(value);
        //}

        // PUT api/<DetailsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Details value)
        //{
        //    Details.PutDetails(id, value);
        //}

        // DELETE api/<DetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteService deleteService = new DeleteService(new Details());
            deleteService.Delete(id);
        }

    }
}
