namespace ArchivexExplorer.Domain.Aggregates
{
    public class ChangePasswordAggregateModel
    {
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
