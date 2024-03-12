namespace ArchivesExplorer.Requests
{
    public class ProductCreateRequestWithImage
    {
        public IFormFileCollection DataFiles { get; set; }
        public ProductCreatingRequest Product { get; set; }
    }
}
