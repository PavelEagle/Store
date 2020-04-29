namespace Store.DB.Models
{
    public class Product_Order
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
