using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;

namespace RestApi.Factories.Implimentations
{
    public class PostFactory : IPostFactory
    {
        private string _sql;
        private Entity _entity;
        public PostFactory(Entity entity)
        {
            _entity = entity;
        }
        public void PostOption()
        {
            _sql = "";
            DatabaseContextPost databaseContextPost = new DatabaseContextPost();
            switch (_entity.GetType().Name)
            {
                case "Customer":
                    Customer customer = (Customer)_entity;
                    _sql = $"insert into customer (number, first_name, last_name, address, vip) " +
                        $"values((select nextval('customer_number_seq')), '{customer.FistName}', '{customer.LastName}', " +
                        $"'{customer.Address}', {customer.Vip.ToString()}); ";
                    break;
                case "Product":
                    break;
                case "Cart":
                    break;
                case "Details":
                    break;
            }
            databaseContextPost.PostSql(_sql);
        }
    }
}
