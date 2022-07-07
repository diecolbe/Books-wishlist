using challenge.emision.shared;

namespace challenge.emision.shared.Models
{
    public class ResponseModel<T> : DefaultHypermediaDocument where T : class
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
