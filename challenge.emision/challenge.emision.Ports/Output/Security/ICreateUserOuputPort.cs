using challenge.emision.dtos.Security;

namespace challenge.emision.ports.Output.Security
{
    public interface ICreateUserOuputPort
    {
        Task Handle(UserRecordedDto user);
    }
}
