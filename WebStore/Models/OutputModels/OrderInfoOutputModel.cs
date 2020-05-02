namespace WebStore.API.Models.OutputModels
{
    public class OrderInfoOutputModel : ProductInStoreOutputModel
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string OrderAddress { get; set; }
        public string Date { get; set; }
    }
}
