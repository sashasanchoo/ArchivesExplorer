namespace ArchivesExplorer.DataContext.Entities
{
    public class ImagePath
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
