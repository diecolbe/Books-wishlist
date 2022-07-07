using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.domain.Interfaces.RepositoryPattern;
using challenge.emision.EF.Context;
using Microsoft.Extensions.Logging;

namespace challenge.emision.EF.Repositories
{
    public class CreateBooksWishlistRepository : ICreateBooksWishlistRepository
    {
        private readonly IUnitOfWork<int> unitOfWork;
        private readonly BookswishlistDbContext? context;
        private readonly ILogger<CreateBooksWishlistRepository> log;

        public CreateBooksWishlistRepository(IUnitOfWork<int> unitOfWork,
            BookswishlistDbContext? context,
            ILogger<CreateBooksWishlistRepository> log) =>
            (this.unitOfWork, this.context, this.log) =
             (unitOfWork, context, log);

        public Bookswishlist CreateBooksWishlist(Bookswishlist bookswishlists)
        {
            try
            {
                unitOfWork.Repository<Bookswishlist>().Insert(bookswishlists);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
            return bookswishlists;
        }
    }
}
