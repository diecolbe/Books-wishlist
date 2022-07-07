namespace challenge.emision.dtos
{
    public class BookswishlistAddBooksDto
    {
        public int IdBookswishlist { get; set; }
        public string? User { get; set; }
        public List<BookDto>? Books { get; set; }
    }
}
