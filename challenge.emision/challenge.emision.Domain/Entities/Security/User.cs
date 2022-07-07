namespace challenge.emision.Domain.Entities.Security
{
    public class User
    {
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }


    }
}
