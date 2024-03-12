using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Domain.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ArchivesExplorer.Application.Helpers
{
    public class FileManager : IFileManager
    {
        private readonly FileManagerOptions _fileManagerOptions;
        private readonly string _imagesFullPath;

        public FileManager(IOptions<FileManagerOptions> options, IWebHostEnvironment environment)
        {
            _fileManagerOptions = options.Value;
            _imagesFullPath = Path.Combine(environment.WebRootPath, _fileManagerOptions.ImagesDirectory);
        }
        public async Task CopyFiles(IFormFileCollection formFileCollection)
        {
            foreach(var file in formFileCollection)
            {
                await CopyFile(file);
            }
        }

        private async Task CopyFile(IFormFile file)
        {
            if (!FileExists(file.FileName))
            {
                await using (var stream = new FileStream(Path.Join(_imagesFullPath, file.FileName), FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
        private bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}
