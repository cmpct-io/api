using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Compact.Comments
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsReader _reader;
        private readonly ICommentsWriter _writer;

        public CommentsController(ICommentsReader reader, ICommentsWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        /// <summary>
        /// Get all comments for a specific route
        /// </summary>
        [HttpGet("/api/routes/{routeId}/comments")]
        [ProducesResponseType(typeof(IEnumerable<Comment>), 200)]
        public ActionResult Get(string routeId)
        {
            var response = _reader.Get(routeId);

            return Ok(response);
        }

        /// <summary>
        /// Add a new comment about a route
        /// </summary>
        [HttpPost("/api/comments")]
        public ActionResult Post(PostCommentRequestModel request)
        {
            _writer.Add(request.RouteId, request.Name, request.CommentText);

            return NoContent();
        }
    }
}