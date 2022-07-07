using challenge.emision.domain.Entities;

namespace challenge.emision.domain.Interfaces.Repositories
{
    public interface IAddBooksToWishlistRepository
    {
        List<Book> AddBook(int IdBookswishlist, List<Book>? Books);
    }
}
