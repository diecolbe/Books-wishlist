using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using challenge.emision.EF.Context;
using Microsoft.Extensions.Logging;

namespace challenge.emision.EF.Repositories
{
    public class AddBookToWishlistRepository : IAddBooksToWishlistRepository
    {
        private readonly IUnitOfWork<int> unitOfWork;
        private readonly ILogger<AddBookToWishlistRepository> log;
        private readonly BookswishlistDbContext? context;

        public AddBookToWishlistRepository(IUnitOfWork<int> unitOfWork,
            ILogger<AddBookToWishlistRepository> log,
            BookswishlistDbContext? context)
        {
            this.unitOfWork = unitOfWork;
            this.log = log;
            this.context = context;
        }

        public List<Book> AddBook(int IdBookswishlist, List<Book>? books)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    books.ForEach(async book =>
                    {
                        var existBookInList = await unitOfWork.Repository<Bookswishlist_Book>().
                                                         ExistAsync(f => f.IdBook.Equals(book.Id) &&
                                                         f.IdBookswishlist == IdBookswishlist);

                        if (!existBookInList)
                        {
                            var existBook = await unitOfWork.Repository<Book>().ExistAsync(f => f.Id.Equals(book.Id));
                            if (!existBook)
                                unitOfWork.Repository<Book>().Insert(book);

                            unitOfWork.Repository<Bookswishlist_Book>().Insert(new Bookswishlist_Book()
                            {
                                IdBook = book.Id,
                                IdBookswishlist = IdBookswishlist
                            });
                        }
                    });
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    log.LogError(ex.Message);
                }
            }
            return books;
        }
    }
}
