using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.WriteRepositories
{
    public class CommentWriteRepository : BaseWriteRepository<Comment, CommentModel>, ICommentWriteRepository
    {
        public CommentWriteRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
