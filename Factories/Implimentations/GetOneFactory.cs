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
        public GetOneFactory(Entity _entity)
        {
            entity = _entity;
        }
        public Entity GetOneOption(int number)
        {
            DatabaseContext dbContext = new DatabaseContext();
            switch (entity.WhatIsEntity())
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
