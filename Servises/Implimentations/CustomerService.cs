using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Bases;

namespace RestApi.Servises.Implimentations
{
    public class CustomerService : BaseService<Customer>
    {
        private readonly IRepo<Customer> _repoCustomer;
        public CustomerService(IRepo<Customer> repo) : base(repo)
        {
            _repoCustomer = repo;
        }
        public override void Delete(int id)
        {
            if (_repoCustomer.IsExist(id))
            {
                CustomerValidator validator = new CustomerValidator();
            }
            base.Delete(id);
        }
        public override Customer Get(int id)
        {
            if (_repoCustomer.IsExist(id))
            {
                return base.Get(id);
            }
            return null;
        }
    }
}
