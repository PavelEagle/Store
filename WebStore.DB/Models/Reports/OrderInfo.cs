using System;

namespace WebStore.DB.Models
{
    public class OrderInfo: Order
    {
        public Product Product{ get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
