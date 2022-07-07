using challenge.emision.dtos;

namespace challenge.emision.ports.Output
{
    public interface IAddBookToWishlistOutputPort
    {
        Task Handle(List<BookDto> books);
    }
}
