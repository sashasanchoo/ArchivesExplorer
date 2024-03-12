using ArchivesExplorer.DataContext.Entities;

namespace ArchivesExplorer.Responses
{
    public class ShortProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public CategoryResponse Category { get; set; }
        public List<string> Images { get; set; }
    }
}
