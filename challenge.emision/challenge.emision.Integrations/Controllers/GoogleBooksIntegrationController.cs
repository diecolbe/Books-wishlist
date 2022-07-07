using challenge.emision.dtos;
using challenge.emision.ports.Input.GoogleBooks;
using challenge.emision.ports.Output.GoogleBooks;
using challenge.emision.presenters.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challenge.emision.Integrations.Controllers
{
    /// <summary>
    /// [Authorize]
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GoogleBooksIntegrationController : Controller
    {
        private readonly IGoogleSearchBookInputPort googleSearchBookInputPort;
        private readonly IGoogleSearchBookOutputPort googleSearchBookOutputPort;
        private readonly ILogger<GoogleBooksIntegrationController> log;

        public GoogleBooksIntegrationController(IGoogleSearchBookInputPort googleSearchBookInputPort,
            IGoogleSearchBookOutputPort googleSearchBookOutputPort,
            ILogger<GoogleBooksIntegrationController> log
            )
        {
            this.googleSearchBookInputPort = googleSearchBookInputPort;
            this.googleSearchBookOutputPort = googleSearchBookOutputPort;
            this.log = log;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("google-books")]
        public async Task<IActionResult> SearchBook(string query, int offset, int count)
        {
            if (string.IsNullOrEmpty(query) || offset == 0 || count == 0)
                return StatusCode(400);

            await googleSearchBookInputPort.Handle(query, offset, count);
            var result = ((IPresenter<List<GoogleBookDto>>)googleSearchBookOutputPort).Content;

            if (!result.Any())
                return StatusCode(204);

            return StatusCode(200, result);
        }
    }
}
