namespace challenge.emision.ports.Output
{
    public interface IDeleteBookToWishlistOutputPort
    {
        Task Handle(List<string> books);
    }
}
