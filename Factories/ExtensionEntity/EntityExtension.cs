using RestApi.Domains;
using RestApi.Domains.BaseEntity;

namespace RestApi.Factories.ExtensionEntity
{
    public static class EntityExtension
    {
        public static string SqlGetOne(this Entity entity,int number)
        {
            return $"select * from {entity.GetType().Name} where number={number};";
        }
        public static string SqlGetAll(this Entity entity, int number)
        {
            return $"select * from {entity.GetType().Name} limit {number};";
        }
    }
}
