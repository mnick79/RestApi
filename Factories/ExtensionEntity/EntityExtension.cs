using RestApi.Domains;
using RestApi.Domains.BaseEntity;

namespace RestApi.Factories.ExtensionEntity
{
    public static class EntityExtension
    {
        public static string WhatIsEntity(this Entity entity)
        {
            if (entity is Customer) {return "Customer";}
            if (entity is Product) { return "Product"; }
            if (entity is Cart) { return "Cart"; };
            if (entity is Details) { return "Details"; }
            return null;
        }
        public static string SqlGetOne(this Entity entity,int number)
        {
            return $"select * from {entity.WhatIsEntity()} where number={number};";
        }
        public static string SqlGetAll(this Entity entity, int number)
        {
            return $"select * from {entity.WhatIsEntity()} limit {number};";
        }
    }
}
