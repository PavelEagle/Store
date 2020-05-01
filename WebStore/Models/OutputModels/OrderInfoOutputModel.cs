namespace WebStore.API.Models.OutputModels
{
    public class OrderInfoOutputModel
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string OrderAddress { get; set; }
        public string Date { get; set; }
    }
}
