using challenge.emision.Domain.Entities.Security;
using challenge.emision.dtos;
using challenge.emision.dtos.Security;
using challenge.emision.MongoDb.Documents;
using challenge.emision.MongoDb.Interfaces;
using challenge.emision.ports.Input.Security;
using challenge.emision.ports.Output.Security;
using challenge.emision.shared;
using challenge.emision.shared.Helpers;
using Microsoft.Extensions.Logging;

namespace challenge.emision.UseCases.Security
{
    public class CreateUserUseCase : ICreateUserInputPort
    {
        private readonly ICreateUserOuputPort createUserOuputPort;
        private readonly IMongoRepository<UserDocument> mongoRepository;
        private readonly ILogger<CreateUserUseCase> log;

        public CreateUserUseCase(ICreateUserOuputPort createUserOuputPort,
            IMongoRepository<UserDocument> mongoRepository,
            ILogger<CreateUserUseCase> log) =>
            (this.createUserOuputPort, this.mongoRepository, this.log) =
            (createUserOuputPort, mongoRepository, log);

        public async Task Handle(UserDto user)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                User newUser= Mapper.MapperObject<UserDto, User>(user);
                HelperPasswordHash.CreatePasswordHash(user.Password,out passwordHash, out passwordSalt);
                newUser.PasswordHash=passwordHash;
                newUser.PasswordSalt=passwordSalt;
                
                await mongoRepository.InsertOneAsync(Mapper.MapperObject<User, UserDocument>(newUser));
                await createUserOuputPort.Handle(Mapper.MapperObject<User, UserRecordedDto>(newUser));
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
