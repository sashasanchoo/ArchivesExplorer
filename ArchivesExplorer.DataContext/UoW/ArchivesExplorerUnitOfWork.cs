using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivesExplorer.DataContext.UoW.Base;
using AutoMapper;

namespace ArchivesExplorer.DataContext.UoW
{
    public class ArchivesExplorerUnitOfWork : UnitOfWork, IArchivexExplorerUnitOfWork
    {
        private readonly Lazy<IUserWriteRepository> _userWriteRepository;
        private readonly Lazy<IRoleWriteRepository> _roleWriteRepository;
        private readonly Lazy<ICategoryWriteRepository> _categoryWriteRepository;
        private readonly Lazy<IProductWriteRepository> _productWriteRepository;
        private readonly Lazy<IImagePathWriteRepository> _imagePathWriteRepository;
        private readonly Lazy<ICommentWriteRepository> _commentWriteRepository;
        private readonly Lazy<IOrderWriteRepository> _orderWriteRepository;

        public ArchivesExplorerUnitOfWork(
            ArchivesExplorerDbContext dbContext, 
            IMapper mapper,
            IUserWriteRepository userWriteRepository,
            IRoleWriteRepository roleWriteRepository,
            ICategoryWriteRepository categoryWriteRepository,
            IProductWriteRepository productWriteRepository,
            IImagePathWriteRepository imagePathWriteRepository,
            ICommentWriteRepository commentWriteRepository,
            IOrderWriteRepository orderWriteRepository) : base(dbContext, mapper)
        {
            _userWriteRepository = new Lazy<IUserWriteRepository>(() => userWriteRepository);
            _roleWriteRepository = new Lazy<IRoleWriteRepository>(() => roleWriteRepository);
            _categoryWriteRepository = new Lazy<ICategoryWriteRepository>(() => categoryWriteRepository);
            _productWriteRepository = new Lazy<IProductWriteRepository>(() => productWriteRepository);
            _imagePathWriteRepository = new Lazy<IImagePathWriteRepository>(() => imagePathWriteRepository);
            _commentWriteRepository = new Lazy<ICommentWriteRepository>(() => commentWriteRepository);
            _orderWriteRepository = new Lazy<IOrderWriteRepository>(() => orderWriteRepository);
        }

        public IUserWriteRepository Users
        {
            get => _userWriteRepository.Value;
        }

        public IRoleWriteRepository Roles
        {
            get => _roleWriteRepository.Value;
        }

        public ICategoryWriteRepository Categories
        {
            get => _categoryWriteRepository.Value;
        }

        public IProductWriteRepository Products
        {
            get => _productWriteRepository.Value;
        }

        public IImagePathWriteRepository Images
        {
            get => _imagePathWriteRepository.Value;
        }

        public ICommentWriteRepository Comments
        {
            get => _commentWriteRepository.Value;
        }

        public IOrderWriteRepository Orders
        {
            get => _orderWriteRepository.Value;
        }
    }
}
