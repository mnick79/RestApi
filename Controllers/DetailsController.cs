using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Servises.Implimentations;
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
        public Details Get(int id) // cart_number из таблицы cart
        {
            GetOneService getOneService = new GetOneService(new Details());
            return (Details)getOneService.GetOne(id);
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
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    Details.DeleteOneDetails(id);
        //}

    }
}
