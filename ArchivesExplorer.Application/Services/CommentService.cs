using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;

        public CommentService(IArchivexExplorerUnitOfWork unitOfWork, IUserReadRepository userReadRepository)
        {
            _unitOfWork = unitOfWork;
            _userReadRepository = userReadRepository;
        }

        public async Task CreateComment(CommentModel comment, Guid userId)
        {
            var user = await _userReadRepository.GetUniqueAsync(x => x.Id == userId);

            comment.Id = Guid.NewGuid();
            comment.Published = DateTime.UtcNow;
            comment.Username = user.Username;

            await _unitOfWork.Comments.AddEntityAsync(comment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteComment(Guid id)
        {
            await _unitOfWork.Comments.DeleteEntityByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
