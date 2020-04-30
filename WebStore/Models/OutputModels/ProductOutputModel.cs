using WebStore.DB.Models;

namespace WebStore.API.Models.OutputModels
{
    public class ProductOutputModel
    {
        public int? Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Subcategory { get; set; }
    }
}
