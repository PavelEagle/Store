namespace WebStore.API.Models.OutputModels
{
    public class ProductOutputModel : ShortProductOutputModel
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; }
        public string Subcategory { get; set; }
    }
}
