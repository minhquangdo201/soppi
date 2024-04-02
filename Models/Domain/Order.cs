using soppi.Data;

namespace soppi.Models {
    public class Order {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}