namespace challenge.emision.dtos.Security
{
    public class UserLoggedDto
    {
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
    }
}
