using System.ComponentModel;
using soppi.Data;

namespace soppi.Models {
    public class Product {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}