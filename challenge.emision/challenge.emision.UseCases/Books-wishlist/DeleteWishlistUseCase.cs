using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.ports.Input;
using challenge.emision.ports.Output;
using Microsoft.Extensions.Logging;

namespace challenge.emision.UseCases
{
    public class DeleteWishlistUseCase : IDeleteWishListInputPort
    {
        private readonly IDeleteWishListOutputPort deleteWishListOutputPort;
        private readonly IDeleteBooksWishlistRepository deleteBooksWishlistRepository;
        private readonly ILogger<DeleteWishlistUseCase> log;

        public DeleteWishlistUseCase(IDeleteWishListOutputPort deleteWishListOutputPort,
            IDeleteBooksWishlistRepository deleteBooksWishlistRepository,
            ILogger<DeleteWishlistUseCase> log) =>
            (this.deleteWishListOutputPort, this.deleteBooksWishlistRepository, this.log)
            = (deleteWishListOutputPort, deleteBooksWishlistRepository, log);

        public async Task Handle(int id)
        {
            try
            {
                bool successful = deleteBooksWishlistRepository.DeleteWishlist(id);
                await deleteWishListOutputPort.Handle(successful);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
