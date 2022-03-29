using Npgsql;
using RestApi.Database.Postgres.Interfaces;
using System;

namespace RestApi.Database.Postgres.Implimentations
{
    public class Postgres: IPostgreSql
    {
        private readonly string _server = "localhost";
        private readonly int _port = 5432;
        private readonly string _username = "postgres";
        private readonly string _password = "123454321";
        private readonly string _database = "demoshop";
        private readonly string _connectString;
        public Postgres()
        {
            _connectString = $"Server={_server};Port={_port};User Id={_username};Password={_password};Database={_database};";
        }
        public NpgsqlConnection Connect()
        {
            NpgsqlConnection conn = new NpgsqlConnection(_connectString);
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
