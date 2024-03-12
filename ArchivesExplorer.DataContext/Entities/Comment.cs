namespace ArchivesExplorer.DataContext.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime Published { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
