using challenge.emision.dtos;

namespace challenge.emision.ports.Input
{
    public interface ICreateBooksWishlistInputport
    {
        Task Handle(CreateBookswishlistDto bookswishlists);
    }
}
