namespace WebStore.DB.Models
{
    public class ProductInStore : Product
    {
        public Store Store { get; set; }
    }
}
