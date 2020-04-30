namespace WebStore.DB.Models
{
    public class Store_Product
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
    }
}
