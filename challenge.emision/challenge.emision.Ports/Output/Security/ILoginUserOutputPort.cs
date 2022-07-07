using challenge.emision.dtos.Security;

namespace challenge.emision.ports.Output.Security
{
    public interface ILoginUserOutputPort
    {
        Task Handle(UserLoggedDto? authUser);
    }
}
