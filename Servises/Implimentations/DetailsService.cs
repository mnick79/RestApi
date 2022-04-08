using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Repository.Implimentation;
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
        public override Details Get(int id)
        {
            if (_repo.IsExist(id))
            {
                return base.Get(id);
            }
            return null;
        }
        //public IEntity Get(int number)
        //{
        //    return _repo.Get(number);
        //}
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
            cart.TotalPrice = sum*discont;
            cart.Description = desc.ToString(0, 254);
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
            cart.TotalPrice = sum*discont;
            cart.Description = desc.ToString(0, 254);
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
            cart.TotalPrice = sum*discont;
            cart.Description = desc.ToString(0, 254);
            repoCart.Put(cart);

        }
        //public List<Details> GetAll(int limit)
        //{
        //    return _repo.GetAll(limit);
        //}
    }
}
