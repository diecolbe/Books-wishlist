using challenge.emision.domain.Entities;

namespace challenge.emision.domain.Interfaces.Repositories
{
    public interface ICreateBooksWishlistRepository
    {
        Bookswishlist CreateBooksWishlist(Bookswishlist bookswishlists);
    }
}
