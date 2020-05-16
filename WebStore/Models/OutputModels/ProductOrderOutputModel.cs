namespace WebStore.API.Models.OutputModels
{
    public class ProductOrderOutputModel: ShortProductOutputModel
    {
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
