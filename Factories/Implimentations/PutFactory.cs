using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Factories.Interfaces;

//namespace RestApi.Factories.Implimentations
//{
//    public class PutFactory : IPutFactory
//    {
//        private string _sql;
//        private readonly Entity _entity;
//        private readonly VipFactory vipFactory;
//        public PutFactory(Entity entity)
//        {
//            _entity = entity;
//            vipFactory = new VipFactory();
//        }
//        public void PutOption(int id)
//        {
//            DatabaseContextPut databaseContextPost = new DatabaseContextPut();

//            switch (_entity.GetType().Name)
//            {
//                case "Customer":
//                    CustomerOld customer = (CustomerOld)_entity;
//                    _sql = $"update customer set first_name='{customer.FistName}', last_name='{customer.LastName}'," +
//                        $"address='{customer.Address}', vip={customer.Vip} where number={id}";
//                    break;
//                case "Product":
//                    ProductOld product = (ProductOld)_entity;
//                    _sql = $"update product set name='{product.Name}', price = {product.Price} where number={id};";
//                    break;
//                case "Cart":
//                    CartOld cart = (CartOld)_entity;
//                    _sql = $"update cart set customer_number={cart.CustomerNumber} where number={id};";
//                    //Внесение автосуммы
//                    _sql += vipFactory.AutoSumm(cart, id);
//                    // Реализация автозаполнения после побавления новой детализации
//                    _sql += vipFactory.AutoDescription(id);
//                    break;
//                case "Details":
//                    DetailsOld details = (DetailsOld)_entity;
//                    _sql = $"update details set cart_number = {details.CartNumber}, product_number={details.ProductNumber}," +
//                        $" count={details.Count} where number={id};";
//                    //Внесение изменений в заказ после изменения в детализации
//                    // Автосуммы в поле cart.Totalprice, если значение по умолчанию (равно нулю)
//                    _sql += vipFactory.AutoSumm(details, details.CartNumber);

//                    // Реализация автозаполнения после побавления новой детализации
//                    _sql += vipFactory.AutoDescription(details.CartNumber);
//                    break;
//            }
//            databaseContextPost.PutSql(_sql);
//        }
//    }
//}
