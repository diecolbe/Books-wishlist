using challenge.emision.domain.Common;
using challenge.emision.domain.Entities;
using challenge.emision.domain.Interfaces.Repositories;
using Google.Apis.Books.v1;
using Google.Apis.Services;

namespace challenge.emision.GoogleIntegrations.Repositories
{
    public class GoogleBooksRepository : IGoogleBooksRepository
    {
        private readonly BooksService _booksService;
        private readonly GoogleBookConfiguration googleBookConfiguration;
        public GoogleBooksRepository(GoogleBookConfiguration googleBookConfiguration)
        {
            this.googleBookConfiguration = googleBookConfiguration;
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = googleBookConfiguration.Apikey,
                ApplicationName = this.GetType().ToString()
            });
        }
        public List<GoogleBook> Search(string query, int offset, int count)
        {
            var listquery = _booksService.Volumes.List(query);
            listquery.MaxResults = count;
            listquery.StartIndex = offset;
            var res = listquery.Execute();
           
            var books = res.Items.Select(b => new GoogleBook
            {
                Id = b.Id,
                Title = b.VolumeInfo.Title,
                Description = b.VolumeInfo.Description,
                Authors = b.VolumeInfo.Authors.ToList(),
                Publisher = b.VolumeInfo.Publisher
            }).ToList();

            return books;
        }
    }
}
