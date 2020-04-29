namespace Store.DB.Models
{
    public class Store
    {
        public int? Id { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
    }
}
