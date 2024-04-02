namespace soppi.Models {
    public class Review {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public virtual Product Product { get; set; }
    }
}