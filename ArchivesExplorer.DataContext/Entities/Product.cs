namespace ArchivesExplorer.DataContext.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ImagePath> Images { get; set; }
        public List<Order> Orders { get; set; }
    }
}
