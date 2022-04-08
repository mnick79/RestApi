using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Repository.Implimentation;
using RestApi.Repository.Vip;
using RestApi.Servises.Bases;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Servises.Implimentations
{
    public class DetailsService: BaseService<Details>
    {
        private readonly IRepo<Details> _repo;
        public DetailsService(IRepo<Details> repo): base(repo)
        {
            _repo = repo;
        }
        public override List<Details> GetAll(int cartNumber)
        {
            if (new RepoCart().IsExist(cartNumber))
            {
                return _repo.GetAll(cartNumber);
            }
            return null;
        }

        public override void Delete(int number)
        {
            Details details = new RepoDetails().Get(number);
            base.Delete(number);
            decimal sum = 0;
            StringBuilder desc = new StringBuilder();
            RepoCart repoCart = new RepoCart();
            Cart cart = repoCart.Get(details.CartNumber);
            List<Details> list = new RepoDetails().GetAll(cart.Number);
            foreach (Details detail in list)
            {
                Product product = new RepoProduct().Get(details.ProductNumber);
                sum += details.Count * product.Price;
                desc.Append(product.Name + "/count:" + details.Count.ToString() + "/price:" + product.Name.ToString());
            }
            cart.TotalPrice = new IsVip().FromDetails(details) ? sum * discont : sum;
            if (desc.Length > 254) { desc.Remove(254, desc.Length - 254 - 1); }
            cart.Description = desc.ToString();
            repoCart.Put(cart);
        }
        public override void Post(Details details)
        {
            base.Post(details);
            decimal sum = 0;
            StringBuilder desc = new StringBuilder();
            RepoCart repoCart = new RepoCart();
            Cart cart = repoCart.Get(details.CartNumber);
            List<Details> list = new RepoDetails().GetAll(cart.Number);
            foreach (Details detail in list)
            {
                Product product = new RepoProduct().Get(details.ProductNumber);
                sum += details.Count * product.Price;
                desc.Append(product.Name + "/count:" + details.Count.ToString() + "/price:" + product.Name.ToString());
            }
            cart.TotalPrice = new IsVip().FromDetails(details) ? sum * discont : sum;
            if (desc.Length > 254) { desc.Remove(254, desc.Length-254-1); }

            cart.Description = desc.ToString();
            repoCart.Put(cart);
            
        }
        public override void Put(Details details)
        {
            base.Put(details);
            decimal sum = 0;
            StringBuilder desc = new StringBuilder();
            RepoCart repoCart = new RepoCart();
            Cart cart = repoCart.Get(details.CartNumber);
            List<Details> list = new RepoDetails().GetAll(cart.Number);
            foreach (Details detail in list)
            {
                Product product = new RepoProduct().Get(details.ProductNumber);
                sum += details.Count * product.Price;
                desc.Append(product.Name + "/count:" + details.Count.ToString() + "/price:" + product.Name.ToString());
            }
            cart.TotalPrice = new IsVip().FromDetails(details) ? sum * discont : sum;
            if (desc.Length > 254) { desc.Remove(254, desc.Length - 254 - 1); }
            cart.Description = desc.ToString();
            repoCart.Put(cart);

        }
    }
}
