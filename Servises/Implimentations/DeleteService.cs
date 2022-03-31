using RestApi.Domains.BaseEntity;
using RestApi.Factories.Implimentations;
using RestApi.Servises.Interfaces;
namespace RestApi.Servises.Implimentations
{
    public class DeleteService : IDeleteServise
    {
        DeleteFactory _deleteFactory;
        public DeleteService(DeleteFactory deleteFactory)
        {
            _deleteFactory = deleteFactory;
        }
        public void Delete(int id)
        {
            _deleteFactory.DeleteOption(id);
        }
    }
}
