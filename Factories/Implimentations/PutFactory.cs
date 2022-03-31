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
        private VipFactory vipFactory;
        public PutFactory(Entity entity)
        {
            _entity = entity;
            vipFactory = new VipFactory();
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
                    _sql = $"update cart set customer_number={cart.CustomerNumber} where number={id};";
                    //Внесение автосуммы
                    _sql += vipFactory.AutoSumm(cart, id);
                    // Реализация автозаполнения после побавления новой детализации
                    _sql += vipFactory.AutoDescription(id);
                    //_sql += $@"update cart as cart1
                    //            set description = (select 
                    //            SUBSTRING(
                    //            STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                    //            FROM 0 FOR 254) 
                    //            from customer c 
                    //            join  cart on c.number=cart.customer_number 
                    //            join details d on cart.number=d.cart_number 
                    //            join product p on d.product_number=p.number 
                    //            where cart.customer_number=cart1.customer_number)
                    //            where cart1.number={cart.Number};";
                    break;
                case "Details":
                    Details details = (Details)_entity;
                    _sql = $"update details set cart_number = {details.CartNumber}, product_number={details.ProductNumber}," +
                        $" count={details.Count} where number={id};";
                    //Внесение изменений в заказ после изменения в детализации
                    VipFactory vipFactory1 = new VipFactory();
                    // Автосуммы в поле cart.Totalprice, если значение по умолчанию (равно нулю)
                    _sql += vipFactory.AutoSumm(details, details.CartNumber);

                    // Реализация автозаполнения после побавления новой детализации
                    _sql += vipFactory.AutoDescription(details.CartNumber);
                    //_sql += $@"update cart as cart1
                    //            set description = (select 
                    //            SUBSTRING(
                    //            STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                    //            FROM 0 FOR 254) 
                    //            from customer c 
                    //            join  cart on c.number=cart.customer_number 
                    //            join details d on cart.number=d.cart_number 
                    //            join product p on d.product_number=p.number 
                    //            where cart.customer_number=cart1.customer_number)
                    //            where cart1.number={details.CartNumber};";
                    break;
            }
            databaseContextPost.PutSql(_sql);
        }
    }
}
