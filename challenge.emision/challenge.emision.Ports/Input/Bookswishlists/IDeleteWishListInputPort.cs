namespace challenge.emision.ports.Input
{
    public interface IDeleteWishListInputPort
    {
        Task Handle(int id);
    }
}
