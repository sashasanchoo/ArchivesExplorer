namespace ArchivexExplorer.Domain.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime Published { get; set; }
        public Guid ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
