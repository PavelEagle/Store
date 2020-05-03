using System;

namespace WebStore.DB.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public Store Store { get; set; }
        public string OrderAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
