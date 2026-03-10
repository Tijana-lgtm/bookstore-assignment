namespace BookstoreApplication.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CoverDate { get; set; }
        public string? IssueNumber { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public int ExternalApiId { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int AvailableCopies { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
