namespace WebStore.API.Models.OutputModels
{
    public class ProductInStoreOutputModel: ShortProductOutputModel
    {
        public string City { get; set; }
        public string Address { get; set; }
    }
}
