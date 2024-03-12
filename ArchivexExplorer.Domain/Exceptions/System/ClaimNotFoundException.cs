namespace ArchivexExplorer.Domain.Exceptions.System
{
    public class ClaimNotFoundException : Exception
    {
        public ClaimNotFoundException(string claim) : base($"Claim {claim} not found") { }
    }
}
