using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;

namespace RestApi.Factories.Implimentations
{
    public class PutFactory : IPutFactory
    {
        private string _sql;
        private readonly Entity _entity;
        public PutFactory(Entity entity)
        {
            _entity = entity;
        }
        public void PutOption(int id)
        {
            DatabaseContextPut databaseContextPost = new DatabaseContextPut();
            switch (_entity.GetType().Name)
            {
                case "Customer":
                    Customer customer = (Customer)_entity;
                    _sql = $"update customer set first_name='{customer.FistName}', last_name='{customer.LastName}'," +
                        $"address='{customer.Address}', vip={customer.Vip.ToString()} where number={id}";
                    break;
                case "Product":
                    Product product = (Product)_entity;
                    _sql = $"update product set name='{product.Name}', price = {product.Price} where number={id};";
                    break;
                case "Cart":
                    Cart cart = (Cart)_entity;
                    _sql = $"update cart set totalprice = {cart.TotalPrice}, description='{cart.Description}', " +
                        $"customer_number={cart.CustomerNumber} where number={id};";
                    break;
                case "Details":
                    Details details = (Details)_entity;
                    _sql = $"update details set cart_number = {details.CartNumber}, product_number={details.ProductNumber}," +
                        $" count={details.Count} where number={id};";
                    break;
            }
            databaseContextPost.PutSql(_sql);
        }
    }
}
