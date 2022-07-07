namespace challenge.emision.dtos.Security
{
    public class UserRecordedDto
    {
        public string? Username { get; set; }
        public byte[]? passwordHash { get; set; }
    }
}
