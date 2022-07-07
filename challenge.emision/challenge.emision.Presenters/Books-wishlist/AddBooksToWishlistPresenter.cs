using challenge.emision.dtos;
using challenge.emision.ports.Output;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Books_wishlist
{
    public class AddBooksToWishlistPresenter : IAddBookToWishlistOutputPort, IPresenter<List<BookDto>>
    {
        public List<BookDto>? Content { get; private set; }

        public Task Handle(List<BookDto> books)
        {
            Content = books;
            return Task.CompletedTask;
        }
    }
}
