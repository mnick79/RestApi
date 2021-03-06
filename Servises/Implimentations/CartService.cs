using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Servises.Bases;
using System.Collections.Generic;
using RestApi.Domains.Validation;
using RestApi.Repository.Implimentation;
using System.Text;
using RestApi.Repository.Vip;
using RestApi.Models.Validation;
using System.Linq;
using System;

namespace RestApi.Servises.Implimentations
{
    public class CartService : BaseService<Cart>
    {
        private readonly IRepo<Cart> _repo;
        public CartService(IRepo<Cart> repo) : base(repo)
        {
            _repo = repo;
        }
        public override List<Cart> GetAll(int id)
        {
            if (_repo.IsExist(id)) { return base.GetAll(id); }
            return null;
        }
        public override bool Put(Cart cart)
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
                    desc.Append(product.Name + "/count:" + details.Count.ToString() + "/price:" + product.Price.ToString()+"|");
                }

                cart.TotalPrice = new IsVip().FromCart(cart) ? Math.Round(sum * discont,2) : sum;

                if (desc.Length > 254) { desc.Remove(254, desc.Length - 254 - 1); }
                cart.Description = desc.ToString();
                _repo.Put(cart);
                return true;
            }
            return false;
        }
    }
}
