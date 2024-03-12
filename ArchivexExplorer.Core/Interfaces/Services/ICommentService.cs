using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface ICommentService
    {
        Task CreateComment(CommentModel comment, Guid userId);
        Task DeleteComment(Guid id);
    }
}
