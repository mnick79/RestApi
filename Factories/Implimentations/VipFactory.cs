using RestApi.DBContext.Implimentations.Vip;

namespace RestApi.Factories.Implimentations
{
    public class VipFactory
    {
        private string _sqlSearchInDetails;
        private string _sqlSearchInCart;
        private string _sqlSearchInCustomer;
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
            _sqlSearchInCart = $"select customer_number from cart where number={cartNumber}";
            return databaseContextVip.SearchVipInCartSql(_sqlSearchInCart);
        }
        public bool SearchVipInCustomer(int customerNumber)
        {
            _sqlSearchInCustomer = $"select vip from customer where number={customerNumber}";
            return databaseContextVip.SearchVipInCustomerSql(_sqlSearchInCustomer);
        }
    }
}
