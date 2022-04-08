using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Bases;
using System.Collections.Generic;
using RestApi.Domains.Validation;
using RestApi.Repository.Implimentation;
using System.Text;

namespace RestApi.Servises.Implimentations
{
    public class CartService : BaseService<Cart>
    {
        private readonly IRepo<Cart> _repo;
        public CartService(IRepo<Cart> repo) : base(repo)
        {
            _repo = repo;
        }
        //public override Cart Get(int id)
        //{
        //    if (_repo.IsExist(id))
        //    {
        //        return base.Get(id);
        //    }
        //    return null;
        //}
        //public void Delete(int number) => _repo.Delete(number);

        //public override void Post(Cart cart)
        //{
        //    _repo.Post(cart);
        //}
        public override void Put(Cart cart)
        {
            if (_repo.IsExist(cart.Number))
            {
                decimal sum = 0;
                StringBuilder desc = new StringBuilder();
                List<Details> list = new RepoDetails().GetAll(cart.Number);
                foreach (Details details in list)
                {
                    Product product = new RepoProduct().Get(details.ProductNumber);
                    sum += details.Count * product.Price;
                    desc.Append(product.Name + "/count:" + details.Count.ToString()+"/price:"+product.Name.ToString());
                }
                cart.TotalPrice = sum;
                cart.Description = desc.ToString(0,254);
                _repo.Put(cart);

            }

            //}
            //public List<Cart> GetAll(int limit)
            //{
            //    return _repo.GetAll(limit);
            //}

        }
    }
}
