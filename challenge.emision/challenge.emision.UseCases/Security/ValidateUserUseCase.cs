using challenge.emision.MongoDb.Documents;
using challenge.emision.MongoDb.Interfaces;
using challenge.emision.ports.Input.Security;
using challenge.emision.ports.Output.Security;
using Microsoft.Extensions.Logging;

namespace challenge.emision.UseCases.Security
{
    public class ValidateUserUseCase : IValidateUserInputPort
    {
        private readonly IValidateUserOutputPort validateUserOutputPort;
        private readonly IMongoRepository<UserDocument> mongoRepository;
        private readonly ILogger<ValidateUserUseCase> log;

        public ValidateUserUseCase(IValidateUserOutputPort validateUserOutputPort,
            IMongoRepository<UserDocument> mongoRepository,
            ILogger<ValidateUserUseCase> log) =>
            (this.validateUserOutputPort, this.mongoRepository, this.log) =
             (validateUserOutputPort, mongoRepository, log);

        public async Task Handle(string? userName)
        {
            try
            {
                var userExists = await mongoRepository.FindOneAsync(d => d.Username.ToUpper() == userName.ToUpper());
                if (userExists != null)
                    await validateUserOutputPort.Handle(true);
                else
                    await validateUserOutputPort.Handle(false);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
