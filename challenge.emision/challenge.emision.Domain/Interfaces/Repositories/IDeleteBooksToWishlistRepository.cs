using challenge.emision.domain.Entities;

namespace challenge.emision.domain.Interfaces.Repositories
{
    public interface IDeleteBooksToWishlistRepository
    {
        bool DeleteBookToWishlist(int IdBookswishlist, List<string>? books);
    }
}
