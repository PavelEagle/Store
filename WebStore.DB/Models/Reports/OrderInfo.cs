using System.Collections.Generic;

namespace WebStore.DB.Models
{
    public class OrderInfo: Order
    {
        public long OrderId { get; set; }
        public List<Product_Order> Products { get; set; }
    }
}
