namespace ArchivexExplorer.Domain.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
