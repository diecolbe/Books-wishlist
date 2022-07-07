using challenge.emision.dtos;

namespace challenge.emision.ports.Input
{
    public interface IAddBookToWishlistInputPort
    {
        Task Handle(BookswishlistAddBooksDto newBooks);
    }
}
