using System.ComponentModel.DataAnnotations;

namespace soppi.Models.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; }
        public string UserId { get; set;}
    }
}
