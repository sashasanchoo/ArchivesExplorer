namespace ArchivexExplorer.Domain.Models
{
    public class ImagePathModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }
    }
}
