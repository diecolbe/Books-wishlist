namespace challenge.emision.dtos
{
    public class BookswishlistDto
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public DateTime? CreationDate { get; set; }
        public int NumberBookswishlist { get; set; }
        public virtual List<BookDto>? Books { get; set; }
    }
}
