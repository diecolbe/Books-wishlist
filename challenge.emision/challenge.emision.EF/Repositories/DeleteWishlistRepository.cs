using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using challenge.emision.EF.Context;
using Microsoft.Extensions.Logging;

namespace challenge.emision.EF.Repositories
{
    public class DeleteWishlistRepository : IDeleteBooksWishlistRepository
    {
        private readonly IUnitOfWork<int> unitOfWork;
        private readonly BookswishlistDbContext? context;
        private readonly ILogger<DeleteWishlistRepository> log;

        public DeleteWishlistRepository(IUnitOfWork<int> unitOfWork,
            BookswishlistDbContext? context,
            ILogger<DeleteWishlistRepository> log
            )
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            this.log = log;
        }
        public bool DeleteWishlist(int id)
        {
            bool result = true;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existList = unitOfWork.Repository<Bookswishlist>().Exist(f => f.Id == id);
                    if (existList)
                    {
                        var bookswishlist = unitOfWork.Repository<Bookswishlist>().FirstOrDefault(f => f.Id == id);
                        var bookswishlist_Book = unitOfWork.Repository<Bookswishlist_Book>().FindAll(f => f.IdBookswishlist == id).ToList();

                        unitOfWork.Repository<Bookswishlist>().Delete(bookswishlist);

                        if (bookswishlist_Book.Any())
                            unitOfWork.Repository<Bookswishlist_Book>().Delete(bookswishlist_Book);
                    }
                    unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    log.LogError(ex.Message);
                    result = false;
                }
            }

            return result;
        }
    }
}
