using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivesExplorer.DataContext.UoW.Base;

namespace ArchivesExplorer.DataContext.UoW
{
    public interface IArchivexExplorerUnitOfWork : IUnitOfWork
    {
        public IUserWriteRepository Users { get; }
        public IRoleWriteRepository Roles { get; }
        public ICategoryWriteRepository Categories { get; }
        public IProductWriteRepository Products { get; }
        public IImagePathWriteRepository Images { get; }
        public ICommentWriteRepository Comments { get; }
        public IOrderWriteRepository Orders { get; }
    }
}
