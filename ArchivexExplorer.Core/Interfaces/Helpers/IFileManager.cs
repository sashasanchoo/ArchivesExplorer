using Microsoft.AspNetCore.Http;

namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface IFileManager
    {
        Task CopyFiles(IFormFileCollection formFileCollection);
    }
}
