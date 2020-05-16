using System.Collections.Generic;
using WebStore.DB.Models;

namespace WebStore.API.Models.OutputModels
{
    public class OrderInfoOutputModel
    {

        public int OrderId { get; set; }
        public string City { get; set; }
        public string StoreAddress { get; set; }
        public string OrderAddress { get; set; }
        public string Date { get; set; }
        public List<Product_Order> Products { get; set; }
        
    }
}
