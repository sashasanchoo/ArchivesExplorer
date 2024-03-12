namespace ArchivexExplorer.Domain.Options
{
    public class NotificationPreparerOptions
    {
        public const string SectionName = "NotificationPreparer";
        public string NotificationHtmlFileName { get; set; }
        public string HtmlPagesDirectoryName { get; set; }
        public string NotificationMessageHtmlElementId { get; set; }
        public string ResourceFileRelativePath { get; set; }
    }
}
