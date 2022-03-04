using Npgsql;
using System;

namespace RestApi.ConnBD
{
    // Подключение к постгрес БД mnick, БД не закрывается после выполнения метода.
    public class ConnectDB
    {
        private static readonly string _connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=123454321;Database=demoshop;";
        public static NpgsqlConnection Connect()
        {
            NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

                throw new Exception("Error connecting to the database");
            }
            return conn;
        }
        public static NpgsqlDataReader Reader(string sql)
        {
            NpgsqlConnection conn = ConnectDB.Connect();

            var cmd = new NpgsqlCommand(sql, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            return reader;
             
        }
        public static int? FieldSearch(string sql)
        {
            NpgsqlConnection conn = ConnectDB.Connect();

            var cmd = new NpgsqlCommand(sql, conn);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                return read.GetInt32(0);
            }
            return null;
        }
    }
}
