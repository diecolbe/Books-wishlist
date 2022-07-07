using challenge.emision.dtos;
using challenge.emision.ports.Output;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Books_wishlist
{
    public class CreateBooksWishlistPresenter : ICreateBooksWishlistOutputPort, IPresenter<BookswishlistDto>
    {
        public BookswishlistDto? Content { get; private set; }

        public Task Handle(BookswishlistDto bookswishlists)
        {
            Content = bookswishlists;
            return Task.CompletedTask;
        }
    }
}
