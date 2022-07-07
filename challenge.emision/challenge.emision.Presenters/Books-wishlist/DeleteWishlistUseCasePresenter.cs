using challenge.emision.ports.Output;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Books_wishlist
{
    public class DeleteWishlistUseCasePresenter : IDeleteWishListOutputPort, IPresenter<bool>
    {
        public bool Content { get; private set; }

        public Task Handle(bool successful)
        {
            Content = successful;
            return Task.CompletedTask;
        }
    }
}
