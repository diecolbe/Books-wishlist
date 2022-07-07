using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.dtos;
using challenge.emision.ports.Input;
using challenge.emision.ports.Output;
using challenge.emision.shared;
using Microsoft.Extensions.Logging;

namespace challenge.emision.UseCases
{
    public class DeleteBooksToWishListUseCase : IDeleteBookToWishlistInputPort
    {
        private readonly IDeleteBookToWishlistOutputPort deleteBookToWishlistOutputPort;
        private readonly IDeleteBooksToWishlistRepository deleteBookToWishlistRepository;
        private readonly ILogger<DeleteBooksToWishListUseCase> log;

        public DeleteBooksToWishListUseCase(IDeleteBookToWishlistOutputPort deleteBookToWishlistOutputPort,
            IDeleteBooksToWishlistRepository deleteBookToWishlistRepository,
            ILogger<DeleteBooksToWishListUseCase> log) =>
            (this.deleteBookToWishlistOutputPort, this.deleteBookToWishlistRepository, this.log)
            = (deleteBookToWishlistOutputPort, deleteBookToWishlistRepository, log);

        public async Task Handle(BookswishlistDeleteBooksDto books)
        {
            try
            {
                deleteBookToWishlistRepository.DeleteBookToWishlist(books.IdBookswishlist, books.Books);
                await deleteBookToWishlistOutputPort.Handle(books.Books);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
