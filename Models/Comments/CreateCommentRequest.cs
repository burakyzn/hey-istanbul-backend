using System;
using System.Text.Json.Serialization;

namespace hey_istanbul_backend.Models.Comments
{
    public class CreateCommentRequest
    {
        [JsonIgnore]
        public Guid UserId {get; set; }
        public string LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}