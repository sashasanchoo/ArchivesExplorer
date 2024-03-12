namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface INotificationPreparer<T>
    {
        Task<string> GetNotificationMessage(T order);
    }
}
