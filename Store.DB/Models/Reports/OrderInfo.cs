using System;

namespace Store.DB.Models
{
    public class OrderInfo: Order
    {
        public string City { get; set; }
        public Product Product{ get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
