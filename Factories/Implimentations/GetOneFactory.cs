using RestApi.Database.Postgres.Implimentations;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.Interfaces;
using RestApi.Factories.ExtensionEntity;
using RestApi.DBContext.Implimentations;
using RestApi.Domains;

namespace RestApi.Factories.Implimentations
{
    
    public class GetOneFactory : IGetOneFactory
    {
        private Entity entity;
        private readonly string whatIsEntity;
        public GetOneFactory(Entity _entity)
        {
            entity = _entity;
            whatIsEntity = entity.WhatIsEntity();
        }
        public Entity GetOneOption(int number)
        {
            DatabaseContextSelectOne dbContext = new DatabaseContextSelectOne();
            switch (whatIsEntity)
            {
                case "Customer":
                    return dbContext.SelectOneSql((Customer)entity, entity.SqlGetOne(number));
                case "Product":
                    return dbContext.SelectOneSql((Product)entity, entity.SqlGetOne(number));
                case "Cart":
                    return dbContext.SelectOneSql((Cart)entity, entity.SqlGetOne(number));
                case "Details":
                    return dbContext.SelectOneSql((Details)entity, entity.SqlGetOne(number));
            }
            return entity;
        }

    }
}
