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
        public string First_name { get { return first_name; } set { first_name = value; } }
        public string Last_name { get { return last_name; } set { first_name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public bool Vip { get => vip; set { vip = value; } }

        public Customer() { }
        public Customer(string first_name, string last_name, string address, bool vip)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.vip = vip;
        }
        public Customer(int id, string first_name, string last_name, string address, bool vip)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.vip = vip;
        }


        /*Реализация контруктора 
         * // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get() 
        */
        public static List<Customer> GetAllCustomer(string sql)
        {
            var rezult = new List<Customer>();

            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                rezult.Add(new Customer(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetBoolean(4)));
            }
            return rezult;
        }
        /* Реализация в конструкторе нахождения покупателя по id
         */
        public static Customer GetOnlyOneCustomer(int idCustomer)
        {
            string sql = $"select * from customer where id={idCustomer};";
            var read = ConnectDB.Reader(sql);
            while (read.Read())
                { 
                    return new Customer(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetBoolean(4));
                }

            return new Customer();
        }
        // Переопределения метода ToString для класса Customer
        public static string ToString(Customer client)
        {
            return $"'id':'{client.id}', 'first_name':'{client.first_name}'";

        }
        // Метод добавления нового покупателя
        public static void NewCustomer(Customer value)
        {
            string sql = $"insert into customer (first_name, last_name, address, vip) values ({value.first_name}, {value.last_name}, {value.address}, {value.vip});";

            ConnectDB.ExeNoQuery(sql);
        }


        public static void DeleteCustomer(int idCustomer)
        {
            string onlySelectString = $"delete from customer where id={idCustomer};";

            ConnectDB.ExeNoQuery(onlySelectString);
        }
    }

}
