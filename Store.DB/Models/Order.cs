using System;

namespace Store.DB.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public int StoreId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
    }
}
