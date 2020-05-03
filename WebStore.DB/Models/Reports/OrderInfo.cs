using System;

namespace WebStore.DB.Models
{
    public class OrderInfo: Order
    {
        public Product Product{ get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int OrderId { get; set; }
        public double CurrencyExchangeRate { get; set; }


    }
}
