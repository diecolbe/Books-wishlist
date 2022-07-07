using challenge.emision.shared;

namespace challenge.emision.dtos.Security
{
    public class UserDto : DefaultHypermediaDocument
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
