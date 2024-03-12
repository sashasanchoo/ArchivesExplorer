using System.Reflection;
using System.Resources;

namespace ArchivexExplorer.Domain.Extensions
{
    public class ResourceManagerBuilder
    {
        private string? _baseName;
        private Assembly? _assembly;

        public ResourceManagerBuilder WithBaseName(string baseName)
        {
            _baseName = baseName;
            return this;
        }

        public ResourceManagerBuilder WithAssembly(Assembly assembly)
        {
            _assembly = assembly;
            return this;
        }

        public ResourceManager Build()
        {
            return new ResourceManager(_baseName!, _assembly!);
        }
    }
}
