using System;
using hey_istanbul_backend.Data;
using hey_istanbul_backend.Models;
using hey_istanbul_backend.Models.Comments;
using hey_istanbul_backend.Services.Interfaces;

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
            throw new NotImplementedException();
        }

        public ResultModel<object> DeleteComment(Guid commentId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public ResultModel<object> GetCommentByLocationId(string locationId)
        {
            throw new NotImplementedException();
        }

        public ResultModel<object> GetCommentByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}