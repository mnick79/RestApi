namespace RestApi.Items
{
    public class Products
    {
        private int number;
        private string name;
        private decimal price;

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


    }
}
