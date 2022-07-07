using challenge.emision.dtos;
using challenge.emision.ports.Input;
using challenge.emision.ports.Output;
using challenge.emision.presenters.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace challenge.emision.BookswishlistApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class BookswishlistController : Controller
    {
        private readonly ICreateBooksWishlistInputport createBooksWishlistInputport;
        private readonly IAddBookToWishlistInputPort addBookToWishlistInputPort;
        private readonly IDeleteBookToWishlistInputPort deleteBookToWishlistInputPort;
        private readonly IDeleteWishListInputPort deleteWishListInputPort;


        private readonly ICreateBooksWishlistOutputPort createBooksWishlistOutputPort;
        private readonly IAddBookToWishlistOutputPort addBookToWishlistOutputPort;
        private readonly IDeleteBookToWishlistOutputPort deleteBookToWishlistOutputPort;
        private readonly IDeleteWishListOutputPort deleteWishListOutputPort;

        private readonly ILogger<BookswishlistController> log;

        public BookswishlistController(
            ICreateBooksWishlistInputport createBooksWishlistInputport,
            IAddBookToWishlistInputPort addBookToWishlistInputPort,
            IDeleteBookToWishlistInputPort deleteBookToWishlistInputPort,
            IDeleteWishListInputPort deleteWishListInputPort,
            ICreateBooksWishlistOutputPort createBooksWishlistOutput,
            IAddBookToWishlistOutputPort addBookToWishlistOutputPort,
            IDeleteBookToWishlistOutputPort deleteBookToWishlistOutputPort,
            IDeleteWishListOutputPort deleteWishListOutputPort,
            ILogger<BookswishlistController> log
            )
        {
            this.createBooksWishlistInputport = createBooksWishlistInputport;
            this.addBookToWishlistInputPort = addBookToWishlistInputPort;
            this.deleteBookToWishlistInputPort = deleteBookToWishlistInputPort;
            this.deleteWishListInputPort = deleteWishListInputPort;

            this.createBooksWishlistOutputPort = createBooksWishlistOutput;
            this.addBookToWishlistOutputPort = addBookToWishlistOutputPort;
            this.deleteBookToWishlistOutputPort = deleteBookToWishlistOutputPort;
            this.deleteWishListOutputPort = deleteWishListOutputPort;
            this.log = log;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("wishlist-create")]
        public async Task<IActionResult> Create([FromBody] CreateBookswishlistDto createBookswishlist)
        {
            log.LogInformation("Post BookswishlistController {0}", JsonConvert.SerializeObject(createBookswishlist));

            if (createBookswishlist == null)
                return BadRequest();

            await createBooksWishlistInputport.Handle(createBookswishlist);
            var result = ((IPresenter<BookswishlistDto>)createBooksWishlistOutputPort).Content;

            return StatusCode(201, result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("wishlist-addBook")]
        public async Task<IActionResult> AddNewBook([FromBody] BookswishlistAddBooksDto newBooks)
        {
            log.LogInformation("Post BookswishlistController {0}", JsonConvert.SerializeObject(newBooks));

            if (newBooks == null)
                return BadRequest();

            await addBookToWishlistInputPort.Handle(newBooks);
            var result = ((IPresenter<List<BookDto>>)addBookToWishlistOutputPort).Content;

            return StatusCode(201, result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("wishlist-deleteBook")]
        public async Task<IActionResult> DeleteBook([FromBody] BookswishlistDeleteBooksDto books)
        {
            log.LogInformation("Delete BookswishlistController {0}", JsonConvert.SerializeObject(books));
            if (books == null)
                return BadRequest();

            await deleteBookToWishlistInputPort.Handle(books);
            var result = ((IPresenter<List<string>>)deleteBookToWishlistOutputPort).Content;

            return StatusCode(202, result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("wishlist-delete")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            log.LogInformation("Delete BookswishlistController {0}", id);

            if (id == 0)
                return BadRequest();

            await deleteWishListInputPort.Handle(id);
            bool result = ((IPresenter<bool>)deleteWishListOutputPort).Content;


            if (result)
                return StatusCode(202);
            else
                return StatusCode(204);
        }
    }
}
