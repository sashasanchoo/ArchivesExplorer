namespace ArchivexExplorer.Domain.Aggregates
{
    public class AuthResultAggregateModel
    {
        public bool IsRegularUser { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
