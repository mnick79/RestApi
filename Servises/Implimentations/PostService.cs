using RestApi.Domains.BaseEntity;
using RestApi.Domains.Validation;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;

namespace RestApi.Servises.Implimentations
{
    public class PostService : IPostService
    {
        private readonly PostFactory _postFactory;
        public PostService(PostFactory postFactory)
        {
            _postFactory=postFactory; 
        }
        public void Post()
        {
            _postFactory.PostOption();
        }
    }
}
