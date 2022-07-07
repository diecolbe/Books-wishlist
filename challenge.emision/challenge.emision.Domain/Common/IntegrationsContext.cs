using challenge.emision.Domain.Common;

namespace challenge.emision.domain.Common
{
    public class IntegrationsContext
    {
        public GoogleBookConfiguration? GoogleBookConfiguration { get; set; }
        public CacheConfiguration? CacheConfiguration { get; set; }
        public JwtOptions? JwtOptions { get; set; }
    }
}
