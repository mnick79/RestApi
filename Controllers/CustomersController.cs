using Microsoft.AspNetCore.Mvc;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Domains.Validation;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Implimentations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController> - нет в ТЗ
        //[HttpGet]
        //public List<Customer> Get()
        //{
        //    GetAllService getAllService = new GetAllService(new Customer());
        //    return getAllService.GetAll().Select(x=>(Customer)x).ToList();
        //}

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            GetOneService getOneService = new GetOneService(new GetOneFactory(new Customer()));
            return (Customer)getOneService.GetOne(id);
        }

        // POST api/<CustomersController> -нет в ТЗ
        //[HttpPost]
        //public void Post([FromBody] Customer value)
        //{
        //    PostService postService = new PostService(value);
        //    CustomerValidator customerValidator = new CustomerValidator();
        //    postService.Post();
        //}


        // PUT api/<CustomersController>/5 -нет в ТЗ
        //[HttpPut("{id}")]
        // public void Put(int id, [FromBody] Customer value)
        // {
        //    PutService putService = new PutService(value);
        //    CustomerValidator customerValidator = new CustomerValidator();
        //    putService.Put(id);

        // }
    }
}
