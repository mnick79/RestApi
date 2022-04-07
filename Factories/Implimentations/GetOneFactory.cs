using RestApi.Database.Postgres.Implimentations;
using RestApi.Factories.Interfaces;
using RestApi.DBContext.Implimentations;
using RestApi.Domains;

//namespace RestApi.Factories.Implimentations
//{
    
//    public class GetOneFactory : IGetOneFactory
//    {
//        private readonly Entity entity;
//        public GetOneFactory(Entity _entity)
//        {
//            entity = _entity;
//        }
//        public Entity GetOneOption(int number)
//        {
//            DatabaseContextSelectOne dbContext = new DatabaseContextSelectOne();
//            switch (entity.GetType().Name)
//            {
//                case "Customer":
//                    return dbContext.SelectOneSql((CustomerOld)entity, entity.SqlGetOne(number));
//                case "Product":
//                    return dbContext.SelectOneSql((ProductOld)entity, entity.SqlGetOne(number));
//                case "Cart":
//                    return dbContext.SelectOneSql((CartOld)entity, entity.SqlGetOne(number));
//                case "Details":
//                    return dbContext.SelectOneSql((DetailsOld)entity, entity.SqlGetOne(number));
//                default:
//                    break;
//            }
//            return entity;
//        }
//    }
//}
