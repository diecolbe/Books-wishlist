using challenge.emision.dtos;

namespace challenge.emision.ports.Input
{
    public interface IDeleteBookToWishlistInputPort
    {
        Task Handle(BookswishlistDeleteBooksDto books);
    }
}
