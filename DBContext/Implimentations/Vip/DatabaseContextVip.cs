using Npgsql;
using RestApi.Database.Postgres.Implimentations;
using RestApi.DBContext.Interfaces.Vip;

namespace RestApi.DBContext.Implimentations.Vip
{
    public class DatabaseContextVip : IDatabaseContextVip
    {
        private Postgres database;
        public DatabaseContextVip()
        {
            database = new Postgres();
        }

        public int SearchVipInDetailsSql(string sqlSearchDetailsNumber)
        {
            int rezult = 0;
            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sqlSearchDetailsNumber, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezult = read.GetInt32(1);
                }
                conn.Close();
            }
            return rezult;
        }
        public int SearchVipInCartSql(string sqlSearchCartNumber)
        {
            int rezult = 0;
            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sqlSearchCartNumber, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezult = read.GetInt32(3);
                }
                conn.Close();
            }
            return rezult;
        }
        public bool SearchVipInCustomerSql(string sqlSearchCustomertNumber)
        {
            bool rezult = false;
            using (NpgsqlConnection conn = database.Connect())
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sqlSearchCustomertNumber, conn);
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rezult = read.GetBoolean(4);
                }
                conn.Close();
            }
            return rezult;
        }

    }
}
