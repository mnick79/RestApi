using RestApi.Interfaces;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Servises.Implimentations
{
    public class CartService
    {
        private readonly IRepo<Cart> _repo;
        public CartService(IRepo<Cart> repo)
        {
            _repo = repo;
        }
        public void Delete(int number) => _repo.Delete(number);
       
        public void Post(Cart cart)
        {
            _repo.Post(cart);
        }
        public void Put(Cart cart)
        {
            _repo.Put(cart);
        }
        public List<Cart> GetAll(int limit)
        {
            return _repo.GetAll(limit);
        }

    }
}
