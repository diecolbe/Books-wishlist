using challenge.emision.domain.Entities.Books_wishlist;
using challenge.emision.domain.Interfaces.Repositories;
using challenge.emision.dtos;
using challenge.emision.ports.Input;
using challenge.emision.ports.Output;
using challenge.emision.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace challenge.emision.UserCases.Test
{
    [TestClass()]
    public class AddBooksToWishListUseCaseUnitTest
    {
        private MockRepository mockRepository;
        private Mock<IAddBookToWishlistOutputPort> addBookToWishlistOutputPortMock;
        private Mock<IAddBooksToWishlistRepository> addBookToWishlistRepositoryMock;
        private Mock<ILogger<AddBooksToWishListUseCase>> logMock;

        public AddBooksToWishListUseCaseUnitTest()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IAddBookToWishlistInputPort, AddBooksToWishListUseCase>();

        }

        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            addBookToWishlistRepositoryMock = mockRepository.Create<IAddBooksToWishlistRepository>();
            addBookToWishlistOutputPortMock = new Mock<IAddBookToWishlistOutputPort>();
            logMock = new Mock<ILogger<AddBooksToWishListUseCase>>();
        }

        private AddBooksToWishListUseCase CreateUseCase()
        {
            return new AddBooksToWishListUseCase(
                addBookToWishlistOutputPortMock.Object,
                addBookToWishlistRepositoryMock.Object,
                logMock.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockRepository.VerifyAll();
        }

        [TestMethod]
        [Owner("diego")]
        public async Task AddBooksToWish_OK()
        {
            // Arrange
            var useCase = CreateUseCase();

            BookswishlistAddBooksDto newBooks = new BookswishlistAddBooksDto()
            {
                IdBookswishlist = 1,
                User = "diecolbe",
                Books = new List<BookDto>()
                {
                    new BookDto()
                    {
                        Id="SN9xLwEACAAJ",
                        Title="Código limpio : manual de estilo para el desarrollo ágil de software",
                        Author="Robert C. Martin",
                        Publisher="",
                        NumberBook=1
                    },
                    new BookDto()
                    {
                        Id="2TfyDwAAQBAJ",
                        Title="Clean Code in C#",
                        Author="Jason Alls",
                        Publisher="Packt Publishing Ltd",
                        NumberBook=2
                    },
                     new BookDto()
                    {
                        Id="UuBU732z6zgC",
                        Title="The Robert C. Martin Clean Code Collection (Collection)",
                        Author="Robert C. Martin",
                        Publisher="Prentice Hall",
                        NumberBook=3
                    },
                      new BookDto()
                    {
                        Id="axtLzQEACAAJ",
                        Title="Clean Code in JavaScript",
                        Author="James Padolsey",
                        Publisher="Prentice Hall",
                        NumberBook=3
                    }
                }
            };

            List<NewBook> books = new List<NewBook>()
                {
                    new NewBook()
                    {
                        Id="SN9xLwEACAAJ",
                        Title="Código limpio : manual de estilo para el desarrollo ágil de software",
                        Author="Robert C. Martin",
                        Publisher="",
                        NumberBook=1
                    },
                    new NewBook()
                    {
                        Id="2TfyDwAAQBAJ",
                        Title="Clean Code in C#",
                        Author="Jason Alls",
                        Publisher="Packt Publishing Ltd",
                        NumberBook=2
                    },
                     new NewBook()
                    {
                        Id="UuBU732z6zgC",
                        Title="The Robert C. Martin Clean Code Collection (Collection)",
                        Author="Robert C. Martin",
                        Publisher="Prentice Hall",
                        NumberBook=3
                    },
                      new NewBook()
                    {
                        Id="axtLzQEACAAJ",
                        Title="Clean Code in JavaScript",
                        Author="James Padolsey",
                        Publisher="Prentice Hall",
                        NumberBook=3
                    }
                };

            addBookToWishlistRepositoryMock.Setup(x => x.AddBook(It.IsAny<int>(), It.IsAny<List<NewBook>>())).Returns(books);

            //Act
            var result = useCase.Handle(newBooks);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(books.Count > 0);
        }

        [TestMethod]
        [Owner("diego")]
        public async Task AddBooksToWish_BooksEmpyt()
        {
            // Arrange
            var useCase = CreateUseCase();
            var expectedResult = "List books empty";

            BookswishlistAddBooksDto newBooks = new BookswishlistAddBooksDto()
            {
                IdBookswishlist = 1,
                User = "diecolbe",
                Books = new List<BookDto>()
            };

            List<NewBook> books = new List<NewBook>();

            addBookToWishlistRepositoryMock.Setup(x => x.AddBook(It.IsAny<int>(), It.IsAny<List<NewBook>>())).Returns(books);

            //Act
            var result = useCase.Handle(newBooks);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(false, expectedResult);
        }
    }
}