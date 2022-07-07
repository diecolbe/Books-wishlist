using challenge.emision.dtos.Security;

namespace challenge.emision.ports.Input.Security
{
    public interface ILoginUserInputPort
    {
        Task Handle(UserDto user);
    }
}
