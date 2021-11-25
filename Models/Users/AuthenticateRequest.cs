using System.ComponentModel.DataAnnotations;

namespace hey_istanbul_backend.Models.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Password { get; set; }
    }
}