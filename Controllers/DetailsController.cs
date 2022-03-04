using Microsoft.AspNetCore.Mvc;
using RestApi.Items;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        // GET: api/<DetailsController>
       /* [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       */
        // GET api/<DetailsController>/5
        [HttpGet("{id}")]
        public List<Details> Get(int id)
        {
            return Details.GetListDetailsByCartNumber(id);
        }

     /*   // POST api/<DetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
     */
    }
}
