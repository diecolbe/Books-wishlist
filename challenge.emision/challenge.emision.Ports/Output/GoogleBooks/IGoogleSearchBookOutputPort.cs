using challenge.emision.dtos;

namespace challenge.emision.ports.Output.GoogleBooks
{
    public interface IGoogleSearchBookOutputPort
    {
        Task Handle(List<GoogleBookDto> books);
    }
}
