namespace challenge.emision.ports.Input.Security
{
    public interface IValidateUserInputPort
    {
        Task Handle(string? userName);
    }
}
