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
        //public IEntity Get(int number)
        //{
        //    return _repo.Get(number);
        //}
        //public void Delete(int number)
        //{
        //    _repo.Delete(number);
        //}
        //public void Post(Product product)
        //{
        //    _repo.Post(product);
        //}
        //public void Put(Product product)
        //{
        //    _repo.Put(product);
        //}
        //public List<Product> GetAll(int limit)
        //{
        //    return _repo.GetAll(limit);
        //}
    }
}
