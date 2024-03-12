using System.ComponentModel.DataAnnotations;

namespace ArchivesExplorer.Requests
{
    public class ProductCreatingRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
