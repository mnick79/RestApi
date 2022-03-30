using RestApi.Domains.BaseEntity;
using RestApi.Domains.Validation;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;

namespace RestApi.Servises.Implimentations
{
    public class PostService : IPostService
    {
        private Entity _entity;
        public PostService(Entity entity)
        {
            _entity=entity;
            CustomerValidator customerValidator = new CustomerValidator();
        }
        public void Post()
        {
            PostFactory postFactory = new PostFactory(_entity);
            postFactory.PostOption();
        }
    }
}
