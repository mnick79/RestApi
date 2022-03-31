using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;
namespace RestApi.Factories.Implimentations
{
    public class DeleteFactory : IDeleteFactory
    {
        private string _sql;
        private readonly Entity _entity;
        
        public DeleteFactory(Entity entity)
        {
            _entity=entity;
        }
        public void DeleteOption(int id)
        {
            _sql = $"delete from {_entity.GetType().Name} where number={id};";
            if (_entity.GetType().Name == "Details")
            {
                Details details = (Details)_entity;
                //string _discont = "1";
                //VipFactory vipFactory = new VipFactory();
                //bool _isVip = vipFactory.SearchVipInCustomer(vipFactory.SearchVipInCart(vipFactory.SearchVipInDetails(details.Number)));
                //   if (!_isVip) { _discont = "0.9"; }
                //   _sql += $@"update cart as cart1
                //               set totalprice = (select sum(d.count*p.price)*{_discont} 
                //from cart join details d on cart.number=d.cart_number 
                //join product p on d.product_number=p.number 
                //where cart.customer_number=cart1.customer_number)
                //               where cart1.number={details.CartNumber};";
                VipFactory vipFactory = new VipFactory();
                _sql += vipFactory.AutoSumm(details, id);
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
            }
            DatabaseContextDeleteOne databaseContextDeleteOne=new DatabaseContextDeleteOne();
            databaseContextDeleteOne.DeleteOneSql(_sql);
        }
    }
}
