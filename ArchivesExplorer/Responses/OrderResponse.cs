namespace ArchivesExplorer.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
