using challenge.emision.dtos.Security;
using challenge.emision.ports.Input.Security;
using challenge.emision.ports.Output.Security;
using challenge.emision.presenters.Interfaces;
using iHeartLinks.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace challenge.emision.Security.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //Input ports
        private readonly ICreateUserInputPort createUserInputPort;
        private readonly IValidateUserInputPort validateUserInputPort;

        //Output ports
        private readonly ICreateUserOuputPort createUserOuputPort;
        private readonly IValidateUserOutputPort validateUserOutputPort;

        private readonly IHypermediaService hypermediaService;
        private readonly ILogger<UserController> log;

        public UserController(ICreateUserInputPort createUserInputPort,
            IValidateUserInputPort validateUserInputPort,
            ICreateUserOuputPort createUserOuputPort,
            IValidateUserOutputPort validateUserOutputPort,
            IHypermediaService hypermediaService,
            ILogger<UserController> log)
        {
            this.createUserInputPort = createUserInputPort;
            this.validateUserInputPort = validateUserInputPort;
            this.createUserOuputPort = createUserOuputPort;
            this.validateUserOutputPort = validateUserOutputPort;
            this.hypermediaService = hypermediaService;
            this.log = log;
        }

        [HttpPost("user-register")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            log.LogInformation("Post UserController {0}", JsonConvert.SerializeObject(user));

            if (user == null)
                return StatusCode(400);

            await validateUserInputPort.Handle(user.Username);
            bool existUser = ((IPresenter<bool>)validateUserOutputPort).Content;
            if (existUser)
                return StatusCode(409, "The username is already taken");

            await createUserInputPort.Handle(user);

            UserRecordedDto newUser = ((IPresenter<UserRecordedDto>)createUserOuputPort).Content;
            return StatusCode(201, newUser);
        }
    }
}
