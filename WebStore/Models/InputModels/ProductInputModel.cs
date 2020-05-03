namespace WebStore.API.Models.InputModels
{
    public class ProductInputModel
    {
        public long? Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int? SubcategoryId { get; set; }
    }
}
