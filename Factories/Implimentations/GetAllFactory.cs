using RestApi.DBContext.Implimentations;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using RestApi.Factories.ExtensionEntity;
using RestApi.Factories.Interfaces;
using System.Collections.Generic;

namespace RestApi.Factories.Implimentations
{
    public class GetAllFactory : IGetAllFactory
    {
        public List<Entity> entities;
        private Entity _entity;
        private readonly string whatIsEntity;
        private string sql;
        public GetAllFactory(Entity entity)
        {
            _entity = entity;
            whatIsEntity = entity.WhatIsEntity();
        }
        public List<Entity> GetAllOption(int customer_number = 0, int cart_number = 0)
        {
            DatabaseContextSelectAll dbContext = new DatabaseContextSelectAll();
            switch (whatIsEntity)
            {
                case "Customer":
                    sql = "select * from customer limit 10;";
                    return dbContext.SelectAllSql((Customer)_entity, sql);
                case "Product":
                    sql = "select * from product limit 10;";
                    return dbContext.SelectAllSql((Product)_entity, sql);
                case "Cart":
                    sql = $"select * from cart where customer_number={customer_number};";
                    return dbContext.SelectAllSql((Cart)_entity, sql);
                case "Details":
                    sql = $"select * from details where cart_number={cart_number};";
                    return dbContext.SelectAllSql((Details)_entity, sql);
                default:
                    throw new System.Exception();
            }
        }
    }
}
