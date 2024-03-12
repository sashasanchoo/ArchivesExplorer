namespace ArchivexExplorer.Domain.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<ImagePathModel> Images { get; set; }
    }
}
