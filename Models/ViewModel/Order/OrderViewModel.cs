namespace soppi.Models.ViewModel {
    public class OrderViewModel{
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}