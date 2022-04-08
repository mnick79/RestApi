using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Bases;
using RestApi.Servises.Interfaces;
using System.Collections.Generic;

namespace RestApi.Servises.Implimentations
{
    public class ProductService: BaseService<Product>
    {
        private readonly IRepo<Product> _repo;
        public ProductService(IRepo<Product> repo): base(repo)
        {
            _repo = repo;
        }
        public override Product Get(int id)
        {
            if (_repo.IsExist(id))
            {
                return base.Get(id);
            }
            return null;
        }
    }
}
