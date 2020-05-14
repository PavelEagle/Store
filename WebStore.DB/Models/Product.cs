namespace WebStore.DB.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public Subcategory Subcategory { get; set; }
        public bool isDeleted { get; set; }
    }
}
