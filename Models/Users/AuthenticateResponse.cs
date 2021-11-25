using System;

namespace hey_istanbul_backend.Models.Users
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string JwtToken { get; set; }

        public AuthenticateResponse(Guid id, string jwtToken)
        {
            Id = id;
            JwtToken = jwtToken;
        }
    }
}