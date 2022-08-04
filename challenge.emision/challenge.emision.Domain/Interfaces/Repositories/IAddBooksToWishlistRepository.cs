using challenge.emision.domain.Entities;
using challenge.emision.domain.Entities.Books_wishlist;

namespace challenge.emision.domain.Interfaces.Repositories
{
    public interface IAddBooksToWishlistRepository
    {
        List<NewBook> AddBook(int IdBookswishlist, List<NewBook>? Books);
    }
}
