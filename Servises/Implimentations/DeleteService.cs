using RestApi.Domains.BaseEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;
namespace RestApi.Servises.Implimentations
{
    public class DeleteService : IDeleteServise
    {
        private readonly Entity _entity;
        public DeleteService(Entity entity)
        {
            _entity = entity;
        }
        public void Delete(int id)
        {
            DeleteFactory deleteFactory = new DeleteFactory(_entity);
            deleteFactory.DeleteOption(id);
        }
    }
}
