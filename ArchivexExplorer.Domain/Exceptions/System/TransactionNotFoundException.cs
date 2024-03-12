namespace ArchivexExplorer.Domain.Exceptions.System
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException() : base("Transaction not found")
        {
        }
    }
}
