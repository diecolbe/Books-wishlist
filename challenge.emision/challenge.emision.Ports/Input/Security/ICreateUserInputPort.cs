using challenge.emision.dtos.Security;

namespace challenge.emision.ports.Input.Security
{
    public interface ICreateUserInputPort
    {
        Task Handle(UserDto user);
    }
}
