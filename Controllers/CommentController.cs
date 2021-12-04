using hey_istanbul_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hey_istanbul_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentController : BaseController
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService ){
            _commentService = commentService;
        }
    }
}