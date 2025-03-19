namespace TestWebApi.Domains.Model
{
    public class Product
    {
        public Guid? Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
