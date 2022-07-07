using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using challenge.emision.EF.Context;
using Microsoft.Extensions.Logging;

namespace challenge.emision.EF.Repositories
{
    public class DeleteBookToWishlistRepository : IDeleteBooksToWishlistRepository
    {
        private readonly IUnitOfWork<int> unitOfWork;
        private readonly ILogger<DeleteBookToWishlistRepository> log;
        private readonly BookswishlistDbContext? context;

        public DeleteBookToWishlistRepository(IUnitOfWork<int> unitOfWork,
           BookswishlistDbContext? context,
           ILogger<DeleteBookToWishlistRepository> log) =>
           (this.unitOfWork, this.context, this.log) =
            (unitOfWork, context, log);

        public bool DeleteBookToWishlist(int IdBookswishlist, List<string>? books)
        {
            try
            {
                books.ForEach(book =>
                {
                    var existBookInList = unitOfWork.Repository<Bookswishlist_Book>().Exist(e => e.IdBook.Equals(book.ToString()));

                    if (existBookInList)
                    {
                        var bookToDelete = unitOfWork.Repository<Bookswishlist_Book>().
                        FirstOrDefault(f=>f.IdBook==book.ToString() && f.IdBookswishlist== IdBookswishlist);
                        unitOfWork.Repository<Bookswishlist_Book>().Delete(bookToDelete);
                    }
                });
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
            return unitOfWork.SaveChanges().Result > 1;
        }
    }
}
