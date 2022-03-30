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
        private bool _isVip;
        private string _discont="1";
        public PostFactory(Entity entity)
        {
            _entity = entity;
        }
        public void PostOption()
        {
            _sql = "";
            DatabaseContextPost databaseContextPost = new DatabaseContextPost();
            VipFactory vipFactory = new VipFactory();
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
                    // Определение VIP клиента
                    _isVip = vipFactory.SearchVipInCustomer(vipFactory.SearchVipInCart(cart.Number));
                    
                    _sql = $"insert into cart (number, customer_number) " +
                        $"values((select nextval('cart_number_seq')), {cart.CustomerNumber} );";
                    // Автозаполнения cart.Decription, если cart.Decription равен "" или "string" при заполнении
                    // Реализация на стороне БД
                    if (cart.Description.Trim() == "" || cart.Description.Trim()== "string")
                    {
                        _sql += @"update cart as cart1
                                set description = (select 
                                SUBSTRING(
                                STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                                FROM 0 FOR 254) 
                                from customer c 
                                join  cart on c.number=cart.customer_number 
                                join details d on cart.number=d.cart_number 
                                join product p on d.product_number=p.number 
                                where cart.customer_number=cart1.customer_number)
                                where cart1.number=(select currval('cart_number_seq'));";
                    }
                    else
                    {
                        _sql += $"update cart set cart.description ={cart.Description} where number=(select currval('cart_number_seq'));"; ;
                    }
                    
                    break;
                case "Details":
                    Details details = (Details)_entity;
                    _sql = $"insert into details (number, cart_number, product_number, count) " +
                        $"values ((select nextval('details_number_seq')), {details.CartNumber}, {details.ProductNumber},{details.Count});";
                    // Автосуммы в поле cart.Totalprice, если значение по умолчанию (равно нулю)
                    // Реализация на строне БД. Определение VIP клиента на стороне API
                    _isVip = vipFactory.SearchVipInCustomer(vipFactory.SearchVipInCart(vipFactory.SearchVipInDetails(details.Number)));
                    if (!_isVip) { _discont = "0.9"; }
                    _sql += $@"update cart as cart1
                            set totalprice = (select sum(d.count*p.price)*{_discont} 
					        from cart join details d on cart.number=d.cart_number 
					        join product p on d.product_number=p.number 
					        where cart.customer_number=cart1.customer_number)
                            where cart1.number={details.CartNumber};";
                    // Реализация автозаполнения после побавления новой детализации
                    _sql += $@"update cart as cart1
                                set description = (select 
                                SUBSTRING(
                                STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                                FROM 0 FOR 254) 
                                from customer c 
                                join  cart on c.number=cart.customer_number 
                                join details d on cart.number=d.cart_number 
                                join product p on d.product_number=p.number 
                                where cart.customer_number=cart1.customer_number)
                                where cart1.number={details.CartNumber};";
                    break;
            }
            databaseContextPost.PostSql(_sql);
        }
    }
}
