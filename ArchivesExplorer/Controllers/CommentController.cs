using ArchivesExplorer.Extensions;
using ArchivesExplorer.Requests;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivesExplorer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [Authorize(Policy = AuthorizationPolicyConstants.AccessTokenPolicy)]
        [HttpPost]
        public async Task<ActionResult> CreateComment([FromBody] CreateCommentRequest request)
        {
            var commentModel = _mapper.Map<CommentModel>(request);
            var userId = HttpContext.GetUserId();

            await _commentService.CreateComment(commentModel, userId);

            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserConstants.SuperUserRole)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] string id)
        {
            await _commentService.DeleteComment(Guid.Parse(id));

            return Ok();
        }
    }
}
