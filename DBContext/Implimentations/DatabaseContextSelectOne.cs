using RestApi.Database.Postgres.Implimentations;
using Npgsql;
using RestApi.DBContext.Interfaces;

//namespace RestApi.DBContext.Implimentations
//{
//    public class DatabaseContextSelectOne: IDatabaseContextSelectOne
//    {
//        private readonly Postgres database;

//        public DatabaseContextSelectOne()
//        {
//            database = new Postgres();
//        }
//        public Entity SelectOneSql(Entity entity, string sql) => null;
//        public Entity SelectOneSql(CustomerOld customer, string sql)
//        {
//            using (NpgsqlConnection conn = database.Connect())
//            {
//                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//                var read = cmd.ExecuteReader();
//                while (read.Read())
//                {
//                    customer.Number = read.GetInt32(0);
//                    customer.FistName = read.GetString(1);
//                    customer.LastName = read.GetString(2);
//                    customer.Address = read.GetString(3);
//                    customer.Vip = read.GetBoolean(4);
//                }
//                conn.Close();
//            }
//            return customer;
//        }
//        public Entity SelectOneSql(ProductOld product, string sql)
//        {
//            using (NpgsqlConnection conn = database.Connect())
//            {
//                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//                var read = cmd.ExecuteReader();
//                while (read.Read())
//                {
//                    product.Number = read.GetInt32(0);
//                    product.Name = read.GetString(1);
//                    product.Price = read.GetDecimal(2);
//                }
//                conn.Close();
//            }
//            return product;
//        }
//        public Entity SelectOneSql(CartOld cart, string sql)
//        {
//            using (NpgsqlConnection conn = database.Connect())
//            {
//                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//                var read = cmd.ExecuteReader();
//                while (read.Read())
//                {
//                    cart.Number = read.GetInt32(0);
//                    cart.TotalPrice = read.GetDecimal(1);
//                    cart.Description = read.GetString(2);
//                    cart.CustomerNumber = read.GetInt32(3);
//                }
//                conn.Close();
//            }
//            return cart;
//        }
//        public Entity SelectOneSql(DetailsOld details, string sql)
//        {
//            using (NpgsqlConnection conn = database.Connect())
//            {
//                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
//                var read = cmd.ExecuteReader();
//                while (read.Read())
//                {
//                    details.Number = read.GetInt32(0);
//                    details.CartNumber = read.GetInt32(1);
//                    details.ProductNumber = read.GetInt32(2);
//                    details.Count = read.GetInt32(3);
//                }
//                conn.Close();
//            }
//            return details;
//        }
//    }
//}
