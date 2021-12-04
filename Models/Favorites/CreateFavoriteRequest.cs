using System;
using System.Text.Json.Serialization;

namespace hey_istanbul_backend.Models.Favorites
{
    public class CreateFavoriteRequest
    {
        [JsonIgnore]
        public Guid UserId {get; set; }
        public string LocationId { get; set; }
    }
}