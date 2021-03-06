using RestApi.Domains.Validation;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Models.Validation;
using RestApi.Repository.Implimentation;
using RestApi.Repository.Vip;
using RestApi.Servises.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Servises.Implimentations
{
    public class DetailsService : BaseService<Details>
    {
        private readonly IRepo<Details> _repo;
        public DetailsService(IRepo<Details> repo) : base(repo)
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
        public override bool Delete(int number)
        {
            if (_repo.IsExist(number))
            {
                Details details = new RepoDetails().Get(number);
                base.Delete(number);

                AddDiscontAndAutoDescriptAndAutoSum(details, discont);
                return true;
            }
            return false;
        }
        public override void Post(Details details)
        {
            DetailsValidator validations = new DetailsValidator();
            base.Post(details);

            AddDiscontAndAutoDescriptAndAutoSum(details, discont);
        }
        public override bool Put(Details details)
        {
            if (_repo.IsExist(details.Number))
            {
                DetailsValidator detailsValidator = new DetailsValidator();
                AddDiscontAndAutoDescriptAndAutoSum(details, discont);
                _repo.Put(details);
                return true;
            }
            return false;
        }
        public void AddDiscontAndAutoDescriptAndAutoSum(Details details, decimal discont)
        {
            decimal sum = 0;
            StringBuilder desc = new StringBuilder();
            RepoCart repoCart = new RepoCart();
            Cart cart = repoCart.Get(details.CartNumber);
            List<Details> list = new RepoDetails().GetAll(cart.Number);
            foreach (Details detail in list)
            {
                Product product = new RepoProduct().Get(details.ProductNumber);
                sum += details.Count * product.Price;
                desc.Append(product.Name + "/count:" + details.Count.ToString() + "/price:" + product.Price.ToString()+"|");
            }
            cart.TotalPrice = new IsVip().FromDetails(details) ? Math.Round(sum * discont, 2) : sum;
            if (desc.Length > 254) { desc.Remove(254, desc.Length - 254 - 1); }
            cart.Description = desc.ToString();
            repoCart.Put(cart);
        }
    }
}
