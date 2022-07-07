namespace challenge.emision.ports.Output.Security
{
    public interface IValidateUserOutputPort
    {
        Task Handle(bool exist);
    }
}
