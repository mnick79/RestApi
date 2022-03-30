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
                    Product product = (Product)_entity;
                    _sql = $"insert into product (number, name, price) " +
                        $"values ((select nextval('product_number_seq')), '{product.Name}', {product.Price.ToString().Replace(',','.')});";
                    break;

                case "Cart":
                    Cart cart = (Cart)_entity;
                    _sql = $"insert into cart (number, totalprice, description, customer_number) " +
                        $"values((select nextval('cart_number_seq')), {cart.TotalPrice.ToString().Replace(',','.')}, '{cart.Description}', {cart.CustomerNumber} );";

                    break;
                case "Details":
                    Details details = (Details)_entity;
                    _sql = $"insert into details (number, cart_number, product_number, count) " +
                        $"values ((select nextval('cart_number_seq')), {details.CartNumber}, {details.ProductNumber},{details.Count});";
                    break;
            }
            databaseContextPost.PostSql(_sql);
        }
    }
}
