namespace ArchivexExplorer.Domain.Options
{
    public class UserAuthTokenOptions
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan AccessTokenDuration { get; set; }
        public TimeSpan RefreshTokenDuration { get; set; }
    }
}
