using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.dtos;
using challenge.emision.ports.Input;
using challenge.emision.ports.Output;
using challenge.emision.shared;
using Microsoft.Extensions.Logging;

namespace challenge.emision.UseCases
{
    public class AddBooksToWishListUseCase : IAddBookToWishlistInputPort
    {
        private readonly IAddBookToWishlistOutputPort addBookToWishlistOutputPort;
        private readonly IAddBooksToWishlistRepository addBookToWishlistRepository;
        private readonly ILogger<AddBooksToWishListUseCase> log;

        public AddBooksToWishListUseCase(IAddBookToWishlistOutputPort addBookToWishlistOutputPort,
            IAddBooksToWishlistRepository addBookToWishlistRepository,
            ILogger<AddBooksToWishListUseCase> log) =>
            (this.addBookToWishlistOutputPort, this.addBookToWishlistRepository, this.log) =
            (addBookToWishlistOutputPort, addBookToWishlistRepository, log);

        public async Task Handle(BookswishlistAddBooksDto newBooks)
        {
            try
            {
                var newListBooks = Mapper.MapperList<BookDto, Book>(newBooks.Books);
                var result = Mapper.MapperList<Book, BookDto>(addBookToWishlistRepository.AddBook(newBooks.IdBookswishlist, newListBooks));
                await addBookToWishlistOutputPort.Handle(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
