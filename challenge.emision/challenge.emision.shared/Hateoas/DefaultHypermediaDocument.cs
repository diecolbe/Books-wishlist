using iHeartLinks.Core;
using System.Text.Json.Serialization;

namespace challenge.emision.shared
{
    public class DefaultHypermediaDocument: IHypermediaDocument
    {
        [JsonPropertyName("_links")]
        public IDictionary<string, Link>? Links { get; private set; }

        public void AddLink(string rel, Link link)
        {
            (Links ??= new Dictionary<string, Link>()).Add(rel, link);
        }
    }
}
