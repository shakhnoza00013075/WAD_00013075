namespace DAL_00013075.Models_00013075
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public Author? Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
