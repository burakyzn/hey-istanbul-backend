using System;
using hey_istanbul_backend.Data;
using hey_istanbul_backend.Data.Entities;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Comments;
using hey_istanbul_backend.Services.Interfaces;
using System.Linq;

namespace hey_istanbul_backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public CommentService(ApplicationDbContext dbContext){
            _dbContext = dbContext;
        }

        public ResultModel<object> CreateComment(CreateCommentRequest request)
        {
            CommentEntity newComment = new CommentEntity{
                LocationId = request.LocationId,
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId
            };

            _dbContext.Add(newComment);
            _dbContext.SaveChanges();

            return new ResultModel<object>(data: newComment, message: "The comment has been created.");
        }

        public ResultModel<object> DeleteComment(Guid commentId, Guid userId)
        {
            CommentEntity comment = _dbContext.Comments
                .Where(com => com.Id == commentId)
                .Where(com => com.UserId == userId)
                .Where(com => com.IsActive)
                .SingleOrDefault();
            
            if(comment == null)
                return new ResultModel<object>(message: "The comment couldn't be found!", type: ResultModel<object>.ResultType.FAIL);

            comment.IsActive = false;

            _dbContext.Update(comment);
            _dbContext.SaveChanges();

            return new ResultModel<object>(data: comment, message: "The comment has been removed");
        }

        public ResultModel<object> GetCommentByLocationId(string locationId)
        {
            var commentList = _dbContext.Comments
                .Where(com => com.LocationId == locationId)
                .Where(com => com.IsActive)
                .OrderBy(com => com.Created)
                .ToList();
            
            return new ResultModel<object>(data : commentList);
        }

        public ResultModel<object> GetCommentByUserId(Guid userId)
        {
            var commentList = _dbContext.Comments
                .Where(com => com.UserId == userId)
                .Where(com => com.IsActive)
                .OrderBy(com => com.Created)
                .ToList();
            
            return new ResultModel<object>(data : commentList);
        }
    }
}