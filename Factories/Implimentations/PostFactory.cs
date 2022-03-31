using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;

namespace RestApi.Factories.Implimentations
{
    public class PostFactory : IPostFactory
    {
        private string _sql;
        private readonly Entity _entity;
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
                        $"'{customer.Address}', {customer.Vip}) returning number; " +
                        $"select setval('customer_number_seq', (select max(number) from customer));";
                    break;
                case "Product":
                    Product product = (Product)_entity;
                    _sql = $"insert into product (number, name, price) " +
                        $"values ((select nextval('product_number_seq')), '{product.Name}', {product.Price.ToString().Replace(',','.')}) returning number; " +
                        $"select setval('product_number_seq', (select max(number) from product));";
                    break;

                case "Cart":
                    Cart cart = (Cart)_entity;
                    _sql = $"insert into cart (number, customer_number, totalprice) " +
                        $"values((select nextval('cart_number_seq')), {cart.CustomerNumber}, {cart.TotalPrice} ) returning number; " +
                        $"select setval('cart_number_seq', (select max(number) from cart));";

                    //Автосумма применяется, когда значение по умолчанию не изменялось,
                    //в ином случае вносит изменения суммы автозаполнением
                    _sql += vipFactory.AutoSummForPostCartCurrentSeq(cart);
                    // Автозаполнения cart.Decription, если cart.Decription равен "" или "string" при заполнении
                    // Реализация на стороне БД


                    if (cart.Description.Trim() == "" || cart.Description.Trim()== "string")
                    {
                        _sql += vipFactory.AutoDescription(0);
                    }
                    else
                    {
                        _sql += $"update cart set description ='{cart.Description}' where number=(select currval('cart_number_seq'));";
                    }
                    
                    break;
                case "Details":
                    Details details = (Details)_entity;
                    _sql = $"insert into details (number, cart_number, product_number, count) " +
                        $"values ((select nextval('details_number_seq')), {details.CartNumber}, {details.ProductNumber},{details.Count}) returning number; " +
                        $"select setval('details_number_seq', (select max(number) from details));";

                    // Автосуммы в поле cart.Totalprice, если значение по умолчанию (равно нулю)
                    // Реализация на строне БД. Определение VIP клиента на стороне API

                    _sql += vipFactory.AutoSumm(_entity, details.CartNumber);



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
            databaseContextPost.PostSql(_sql);
        }
    }
}
