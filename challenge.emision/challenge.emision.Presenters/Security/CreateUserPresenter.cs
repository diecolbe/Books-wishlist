using challenge.emision.dtos;
using challenge.emision.dtos.Security;
using challenge.emision.ports.Output.Security;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Security
{
    public class CreateUserPresenter : ICreateUserOuputPort, IPresenter<UserRecordedDto>
    {
        public UserRecordedDto? Content { get; private set; }

        public Task Handle(UserRecordedDto user)
        {
            Content = user;
            return Task.CompletedTask;
        }
    }
}
