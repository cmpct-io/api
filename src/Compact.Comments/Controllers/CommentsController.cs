using Microsoft.AspNetCore.Mvc;

namespace Compact.Comments
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsWriter _writer;

        public CommentsController(ICommentsWriter writer)
        {
            _writer = writer;
        }

        [HttpPost("/api/comments")]
        public ActionResult Post(PostCommentRequestModel request)
        {
            _writer.Add(request.RouteId, request.Name, request.CommentText);

            return NoContent();
        }
    }
}