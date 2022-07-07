using challenge.emision.dtos;
using challenge.emision.ports.Output;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Books_wishlist
{
    public class DeleteBooksToWishListPresenter : IDeleteBookToWishlistOutputPort, IPresenter<List<string>>
    {
        public List<string> Content { get; private set; }

        public Task Handle(List<string> books)
        {
            Content = books;
            return Task.CompletedTask;
        }
    }
}
