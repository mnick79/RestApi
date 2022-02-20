using System.Collections.Generic;
using Npgsql;
using RestApi.ConnBD;
namespace RestApi.Items
{
    public class Customer
    {
        private int id;
        private string first_name;
        private string last_name;
        private string address;
        private bool vip;

        public int Id { get { return id; } set { id = value; } }
        public string First_name { get { return first_name; } set { first_name = value; }}
        public string Last_name { get { return last_name; } set { first_name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public bool Vip { get => vip; set { vip = value; } }

        public Customer(int id, string first_name, string last_name, string address, bool vip)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.vip = vip;
        }

        public static List<Customer> GetAllCustomer(string sql) 
        { 
            var list = new List<Customer>();
            NpgsqlConnection conn = ConnectDB.Connect();
            using(var cmd = new NpgsqlCommand(sql, conn))
            {
                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Customer(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetBoolean(4)));
                }
                
            }

            return list;

        }


    }
}
