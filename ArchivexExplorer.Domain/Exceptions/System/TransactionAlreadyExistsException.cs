namespace ArchivexExplorer.Domain.Exceptions.System
{
    public class TransactionAlreadyExistsException : Exception
    {
        public TransactionAlreadyExistsException() : base("Transaction already exists")
        {
        }
    }
}
