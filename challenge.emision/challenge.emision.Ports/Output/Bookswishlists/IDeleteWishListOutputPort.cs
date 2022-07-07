namespace challenge.emision.ports.Output
{
    public interface IDeleteWishListOutputPort
    {
        Task Handle(bool successful);
    }
}
