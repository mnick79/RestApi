using Npgsql;
using System;

namespace RestApi.ConnBD
{
    public class ConnectDB
    {
        private static readonly string _connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=123454321;Database=mnick;";
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
    }
}
