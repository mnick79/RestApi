using RestApi.DBContext.Implimentations.Vip;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;

namespace RestApi.Factories.Implimentations
{
    public class VipFactory
    {
        private string _sqlSearchInDetails;
        private string _sqlSearchInCart;
        private string _sqlSearchInCustomer;
        private string _sqlAutoSumm;
        private bool _IsVip;
        private string _discont = "1";
        private DatabaseContextVip databaseContextVip;

        public VipFactory()
        {
            databaseContextVip = new DatabaseContextVip();
        }
        public int SearchVipInDetails(int detailsNumber)
        {
            _sqlSearchInDetails = $"select cart_number from details where number={detailsNumber}";
            return databaseContextVip.SearchVipInDetailsSql(_sqlSearchInDetails);
        }
        public int SearchVipInCart(int cartNumber)
        {
            _sqlSearchInCart = $"select customer_number from cart where number={cartNumber};";
            return databaseContextVip.SearchVipInCartSql(_sqlSearchInCart);
        }
        public bool SearchVipInCustomer(int customerNumber)
        {
            _sqlSearchInCustomer = $"select vip from customer where number={customerNumber};";
            return databaseContextVip.SearchVipInCustomerSql(_sqlSearchInCustomer);
        }

        /*
         Создание строки для вычисления суммы после добавления клиентом детализации.
         */
        public string AutoSumm(Entity entity, int cartNumber)
        {
            _sqlAutoSumm = "";
            switch (entity.GetType().Name)
            {
                case "Cart":
                    Cart cart = (Cart)entity;
                    _IsVip = SearchVipInCustomer(cart.CustomerNumber);
                    if (_IsVip) { _discont = "0.9"; }
                    break;
                case "Details":
                    Details details = (Details)entity;
                    _IsVip = SearchVipInCustomer(SearchVipInCart(SearchVipInDetails(cartNumber)));
                    break;
            }
            _sqlAutoSumm += $@"update cart as cart1
                            set totalprice = (select sum(d.count*p.price)*{_discont} 
					        from cart join details d on cart.number=d.cart_number 
					        join product p on d.product_number=p.number 
					        where cart.number={cartNumber})
                            where cart1.number={cartNumber};";
            return _sqlAutoSumm;          
        }

        /*  Формирует строку SQl обновления суммы при заведении нового заказа пользователем.
            Если пользователь оставил поле totalprice по умолчанию (равное нулю), то вносится автосумма "на стороне" БД,
            в противном случае, вносится значение пользователя без анализа "VIP клиента"
        */
        public string AutoSummForPostCartCurrentSeq(Entity entity)

        {
            _sqlAutoSumm = "";
            Cart cart = (Cart)entity;
            if (cart.TotalPrice == 0)
            {
                _IsVip = SearchVipInCustomer(SearchVipInCart(cart.CustomerNumber));
                if (_IsVip) { _discont = "0.9"; }

                _sqlAutoSumm += $@"update cart as cart1
                            set totalprice = (select sum(d.count*p.price)*{_discont} 
					        from cart join details d on cart.number=d.cart_number 
					        join product p on d.product_number=p.number 
					        where cart.customer_number=cart1.customer_number)
                            where cart1.number=(select currval('cart_number_seq'));";
            }
            else
            {
                _sqlAutoSumm = $"update cart set totalprice = {cart.TotalPrice} where number = (select currval('cart_number_seq'));";
            }
            return _sqlAutoSumm;
        }
        /*  Формирует строку SQL обновления для заполнения описания в поле cart.totalprice*/
        //public string AutoDescription()
        //{

        //}
    }
}
