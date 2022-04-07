using RestApi.DBContext.Implimentations;
using RestApi.Factories.Interfaces;
using System.Collections.Generic;

//namespace RestApi.Factories.Implimentations
//{
//    public class GetAllFactory : IGetAllFactory
//    {
//        public List<Entity> entities;
//        private Entity _entity;
//        private string sql;
//        public GetAllFactory(Entity entity)
//        {
//            _entity = entity;
//        }
//        public List<Entity> GetAllOption(int customer_number = 0, int cart_number = 0)
//        {
//            DatabaseContextSelectAll dbContext = new DatabaseContextSelectAll();
//            switch (_entity.GetType().Name)
//            {
//                case "Customer":
//                    sql = "select * from customer limit 10;";
//                    return dbContext.SelectAllSql((CustomerOld)_entity, sql);
//                case "Product":
//                    sql = "select * from product limit 10;";
//                    return dbContext.SelectAllSql((ProductOld)_entity, sql);
//                case "Cart":
//                    sql = $"select * from cart where customer_number={customer_number};";
//                    return dbContext.SelectAllSql((CartOld)_entity, sql);
//                case "Details":
//                    sql = $"select * from details where cart_number={cart_number};";
//                    return dbContext.SelectAllSql((DetailsOld)_entity, sql);
//                default:
//                    throw new System.Exception();
//            }
//        }
//    }
//}
