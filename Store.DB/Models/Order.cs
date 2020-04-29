using System;

namespace Store.DB.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public Store Store { get; set; }
        public DateTime Date { get; set; }
    }
}
