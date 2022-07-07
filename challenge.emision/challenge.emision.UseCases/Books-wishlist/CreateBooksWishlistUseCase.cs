using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.dtos;
using challenge.emision.ports.Input;
using challenge.emision.ports.Output;
using challenge.emision.shared;
using Microsoft.Extensions.Logging;


namespace challenge.emision.UseCases
{
    public class CreateBooksWishlistUseCase : ICreateBooksWishlistInputport
    {
        private readonly ICreateBooksWishlistOutputPort createBooksWishlistOutput;
        private readonly ICreateBooksWishlistRepository createBooksWishlistRepository;
        private readonly ILogger<CreateBooksWishlistUseCase> log;

        public CreateBooksWishlistUseCase(ICreateBooksWishlistOutputPort createBooksWishlistOutput,
            ICreateBooksWishlistRepository createBooksWishlistRepository,
            ILogger<CreateBooksWishlistUseCase> log) =>
            (this.createBooksWishlistOutput, this.createBooksWishlistRepository, this.log)
            = (createBooksWishlistOutput, createBooksWishlistRepository, log);

        public async Task Handle(CreateBookswishlistDto bookswishlists)
        {
            try
            {
                var _bookswishlists = Mapper.MapperObject<CreateBookswishlistDto, Bookswishlist>(bookswishlists);
                var result = Mapper.MapperObject<Bookswishlist, BookswishlistDto>(createBooksWishlistRepository.CreateBooksWishlist(_bookswishlists));
                if (result != null)
                    await createBooksWishlistOutput.Handle(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
