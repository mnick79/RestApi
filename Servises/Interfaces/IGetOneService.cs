using RestApi.Domains.BaseEntity;

namespace RestApi.Servises.Interfaces
{
    public interface IGetOneService
    {
        public Entity GetOne(int number);
    }
}
