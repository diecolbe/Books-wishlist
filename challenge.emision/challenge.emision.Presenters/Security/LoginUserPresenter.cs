using challenge.emision.dtos.Security;
using challenge.emision.ports.Output.Security;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Security
{
    public class LoginUserPresenter : ILoginUserOutputPort, IPresenter<UserLoggedDto>
    {
        public UserLoggedDto? Content { get; private set; }

        public Task Handle(UserLoggedDto? authUser)
        {
            Content = authUser;
            return Task.CompletedTask;
        }
    }
}
