using challenge.emision.dtos;
using challenge.emision.ports.Output.GoogleBooks;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.GoogleBooks
{
    public class GoogleBooksPresenter : IGoogleSearchBookOutputPort, IPresenter<List<GoogleBookDto>>
    {
        public List<GoogleBookDto>? Content { get; private set; }

        public Task Handle(List<GoogleBookDto> books)
        {
            Content = books;
            return Task.CompletedTask;
        }
    }
}
