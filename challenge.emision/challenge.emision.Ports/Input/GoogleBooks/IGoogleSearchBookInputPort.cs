using challenge.emision.domain.Entities;

namespace challenge.emision.ports.Input.GoogleBooks
{
    public interface IGoogleSearchBookInputPort
    {
        Task Handle(string query, int offset, int count);
    }
}
