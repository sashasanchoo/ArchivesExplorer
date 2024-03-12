namespace ArchivesExplorer.Responses
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime Published { get; set; }
    }
}
