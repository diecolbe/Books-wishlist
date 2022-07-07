
using challenge.emision.domain.Entities;

namespace challenge.emision.domain.Interfaces.Repositories
{
    public interface IGoogleBooksRepository
    {
        List<GoogleBook> Search(string query, int offset, int count);
    }
}
