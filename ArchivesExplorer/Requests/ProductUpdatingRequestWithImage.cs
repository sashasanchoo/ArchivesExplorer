namespace ArchivesExplorer.Requests
{
    public class ProductUpdatingRequestWithImage
    {
        public IFormFileCollection DataFiles { get; set; }
        public ProductUpdatingRequest Product { get; set; }
    }
}
