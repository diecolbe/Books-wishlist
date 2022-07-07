namespace challenge.emision.Domain.Common
{
    public class SecurityContext
    {
        public MongoDbSettings? MongoDbSettings { get; set; }

        public JwtOptions? JwtOptions { get; set; }
    }
}
