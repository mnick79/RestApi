using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.Models;

namespace RestApi.Repository.Vip
{
    public class VipAutoComplite
    {
        private string _sql;
        public string PutToCart(Cart cart, decimal discont)
        {
            //Внесение автосуммы
            _sql = $@"update cart as cart1
                            set totalprice = (select sum(d.count * p.price) *{discont}
                            from cart join details d on cart.number = d.cart_number
                            join product p on d.product_number = p.number
                            where cart.number ={cart.Number})
                            where cart1.number ={cart.Number}; ";
            //Внесение автоописания
            _sql += $@"update cart as cart1
                                set description = (select 
                                SUBSTRING(
                                STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                                FROM 0 FOR 254) 
                                from customer c 
                                join  cart on c.number=cart.customer_number 
                                join details d on cart.number=d.cart_number 
                                join product p on d.product_number=p.number 
                                where cart.number={cart.Number})
                                where cart1.number={cart.Number};";
            return _sql;
        }
        public string PostToCart(Cart cart, decimal discont)
        {
            //Внесение автосуммы
            _sql = $@"update cart as cart1
                            set totalprice = (select sum(d.count*p.price)*{discont} 
					        from cart join details d on cart.number=d.cart_number 
					        join product p on d.product_number=p.number 
					        where cart.number=(select currval('cart_number_seq')))
                            where cart1.number=(select currval('cart_number_seq'));";
            //Внесение автоописания
            _sql += @"update cart as cart1
                                set description = (select 
                                SUBSTRING(
                                STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                                FROM 0 FOR 254) 
                                from customer c 
                                join  cart on c.number=cart.customer_number     
                                join details d on cart.number=d.cart_number 
                                join product p on d.product_number=p.number 
                                where cart.customer_number=(select currval('cart_number_seq')))
                                where cart1.number=(select currval('cart_number_seq'));";
            return _sql;
        }
        public string PutAndPostToDetails(Details details, decimal discont)
        {
            //Внесение автосуммы
            _sql = $@"update cart as cart1
                            set totalprice = (select sum(d.count * p.price) *{discont}
                            from cart join details d on cart.number = d.cart_number
                            join product p on d.product_number = p.number
                            where cart.number ={details.CartNumber})
                            where cart1.number ={details.CartNumber}; ";
            //Внесение автоописания
            _sql += $@"update cart as cart1
                                set description = (select 
                                SUBSTRING(
                                STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
                                FROM 0 FOR 254) 
                                from customer c 
                                join  cart on c.number=cart.customer_number 
                                join details d on cart.number=d.cart_number 
                                join product p on d.product_number=p.number 
                                where cart.number={details.CartNumber})
                                where cart1.number={details.CartNumber};";
            return _sql;
        }
    }
}

