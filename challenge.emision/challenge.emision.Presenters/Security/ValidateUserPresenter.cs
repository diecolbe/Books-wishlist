using challenge.emision.ports.Output.Security;
using challenge.emision.presenters.Interfaces;

namespace challenge.emision.presenters.Security
{
    internal class ValidateUserPresenter : IValidateUserOutputPort, IPresenter<bool>
    {
        public bool Content { get; private set; }

        public Task Handle(bool exist)
        {
            Content = exist;
            return Task.CompletedTask;
        }
    }
}
