using challenge.emision.dtos;
using challenge.emision.dtos.Security;
using challenge.emision.MongoDb.Documents;
using challenge.emision.MongoDb.Interfaces;
using challenge.emision.ports.Input.Security;
using challenge.emision.ports.Output.Security;
using challenge.emision.shared;
using challenge.emision.shared.Helpers;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace challenge.emision.UseCases.Security
{
    public class LoginUserUseCase : ILoginUserInputPort
    {
        private readonly ILoginUserOutputPort loginUserOutputPort;
        private readonly ILogger<LoginUserUseCase> log;
        private readonly IMongoRepository<UserDocument> mongoRepository;

        public LoginUserUseCase(ILoginUserOutputPort loginUserOutputPort,
            IMongoRepository<UserDocument> mongoRepository,
            ILogger<LoginUserUseCase> log) =>
            (this.loginUserOutputPort, this.mongoRepository, this.log)
            = (loginUserOutputPort, mongoRepository, log);

        public async Task Handle(UserDto user)
        {
            try
            {
                var loggedUser = await mongoRepository
                    .FindOneAsync(f => f.Username.ToUpper() == user.Username.ToUpper());

                if (loggedUser != null)
                {
                    var validPassword = HelperPasswordHash.ValidatePasswordHash(user.Password, loggedUser.PasswordHash, loggedUser.PasswordSalt);

                    if (validPassword)
                        await loginUserOutputPort.Handle(Mapper.MapperObject<UserDocument, UserLoggedDto>(loggedUser));
                    else
                        await loginUserOutputPort.Handle(null);
                }
                else
                {
                    await loginUserOutputPort.Handle(null);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
