using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.DBContext.Interfaces;
using RestApi.Domains;
using RestApi.Domains.BaseEntity;
using System.Collections.Generic;

namespace RestApi.DBContext.Implimentations
{
    public class DatabaseContextSelectAll : IDatabaseContextSelectAll
    {
        private Postgres database;
        public DatabaseContextSelectAll()
        {
            database = new Postgres();
        }
        public List<Entity> SelectAllSql(Entity entity, string sql) => null;

        public List<Entity> SelectAllSql(Customer customer, string sql)
        {
            List<Entity> list = new List<Entity>();

            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Customer()
                    {
                        Number = read.GetInt32(0),
                        FistName = read.GetString(1),
                        LastName = read.GetString(2),
                        Address = read.GetString(3),
                        Vip = read.GetBoolean(4)
                    });
                }
                conn.Close();
            }
            return list;
        }
        public List<Entity> SelectAllSql(Product customer, string sql)
        {
            List<Entity> list = new List<Entity>();

            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Product()
                    {
                        Number = read.GetInt32(0),
                        Name = read.GetString(1),
                        Price = read.GetDecimal(2)
                });
                }
                conn.Close();
            }
            return list;
        }
        public List<Entity> SelectAllSql(Cart cart, string sql)
        {
            List<Entity> list = new List<Entity>();

            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Cart()
                    {
                        Number = read.GetInt32(0),
                        TotalPrice = read.GetDecimal(1),
                        Description = read.GetString(2),
                        CustomerNumber = read.GetInt32(3)
                });
                }
                conn.Close();
            }
            return list;
        }
        public List<Entity> SelectAllSql(Details details, string sql)
        {
            List<Entity> list = new List<Entity>();

            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Details()
                    {
                        Number = read.GetInt32(0),
                        CartNumber = read.GetInt32(1),
                        ProductNumber = read.GetInt32(2),
                        Count = read.GetInt32(3)
                    });
                }
                conn.Close();
            }
            return list;
        }
    }
}
