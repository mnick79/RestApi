namespace RestApi.DBContext.Interfaces.Vip
{
    public interface IDatabaseContextVip
    {
        public int SearchVipInDetailsSql(string sqlSearchDetailsNumber);
        public int SearchVipInCartSql(string sqlSearchCartNumber);
        public bool SearchVipInCustomerSql(string sqlSearchCustomertNumber);
    }
}
