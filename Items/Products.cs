using System.Collections.Generic;
using Npgsql;
using RestApi.ConnBD;

namespace RestApi.Items
{
    public class Products
    {
        private int number;
        private string name;
        private decimal price;
        public Products() { }
        public Products(int number, string name, decimal price)
        {
            this.number = number;
            this.name = name;
            this.price = price;
        }


        public int Number
        {
            get { return number; }
            set { number = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public static List<Products> GetAllProduct(string sql)
        {
            var rezult = new List<Products>();

            var read = ConnectDB.Reader(sql);
            while (read.Read())
            {
                rezult.Add(new Products(read.GetInt32(0), read.GetString(1), read.GetDecimal(2)));
            }

            return rezult;
        }
        public static Products GetOneProduct(int idProduct)
        {
            string sql = $"select * from product where number={idProduct}";

            var read = ConnectDB.Reader(sql);

            if (read.HasRows)
            {
                while (read.Read())
                {
                    return new Products(read.GetInt32(0), read.GetString(1), read.GetDecimal(2));
                }
            }
            return new Products();
        }
    }
}
