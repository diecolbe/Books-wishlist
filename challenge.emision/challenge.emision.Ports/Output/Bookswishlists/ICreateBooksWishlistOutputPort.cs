using challenge.emision.dtos;

namespace challenge.emision.ports.Output
{
    public interface ICreateBooksWishlistOutputPort
    {
        Task Handle(BookswishlistDto bookswishlists);
    }
}
