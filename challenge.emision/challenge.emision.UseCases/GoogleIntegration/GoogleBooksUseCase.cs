using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.dtos;
using challenge.emision.ports.Input.GoogleBooks;
using challenge.emision.ports.Output.GoogleBooks;
using challenge.emision.shared;
using Microsoft.Extensions.Logging;

namespace challenge.emision.UseCases.GoogleIntegration
{
    public class GoogleBooksUseCase : IGoogleSearchBookInputPort
    {
        private readonly IGoogleSearchBookOutputPort googleSearchBookOutputPort;
        private readonly IGoogleBooksRepository googleBooksRepository;
        private readonly ILogger<GoogleBooksUseCase> log;

        public GoogleBooksUseCase(IGoogleSearchBookOutputPort googleSearchBookOutputPort,
            IGoogleBooksRepository googleBooksRepository,
            ILogger<GoogleBooksUseCase> log) =>
            (this.googleSearchBookOutputPort, this.googleBooksRepository, this.log) =
            (googleSearchBookOutputPort, googleBooksRepository, log);

        public async Task Handle(string query, int offset, int count)
        {
            try
            {
                var books = googleBooksRepository.Search(query, offset, count);
                var result = Mapper.MapperList<GoogleBook, GoogleBookDto>(books);
                await googleSearchBookOutputPort.Handle(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
