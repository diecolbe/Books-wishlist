namespace challenge.emision.shared.Helpers
{
    public class PasswordDto
    {
        public byte[]? Hash { get; set; }
        public byte[]? Salt { get; set; }
    }
}
