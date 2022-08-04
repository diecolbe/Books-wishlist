using challenge.emision.domain.Entities;
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
    public class CreateBooksWishlistUseCaseUnitTest
    {
        private MockRepository mockRepository;
        private Mock<ICreateBooksWishlistOutputPort> createBooksWishlistOutputMock;
        private Mock<ICreateBooksWishlistRepository> createBooksWishlistRepositoryMock;
        private Mock<ILogger<CreateBooksWishlistUseCase>> logMock;


        public CreateBooksWishlistUseCaseUnitTest()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<ICreateBooksWishlistInputport, CreateBooksWishlistUseCase>();
        }

        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            createBooksWishlistOutputMock = new Mock<ICreateBooksWishlistOutputPort>();
            createBooksWishlistRepositoryMock = mockRepository.Create<ICreateBooksWishlistRepository>();
            logMock = new Mock<ILogger<CreateBooksWishlistUseCase>>();
        }

        private CreateBooksWishlistUseCase CreateUseCase()
        {
            return new CreateBooksWishlistUseCase(
                createBooksWishlistOutputMock.Object,
                createBooksWishlistRepositoryMock.Object,
                logMock.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockRepository.VerifyAll();
        }

        [TestMethod]
        [Owner("diego")]
        public async Task CreateBooksWishlist_Ok()
        {
            // Arrange
            var useCase = CreateUseCase();


            CreateBookswishlistDto createBookswishlistDto = new CreateBookswishlistDto()
            {
                User = "diecolbe",
                CreationDate = DateTime.Now,
                NumberBookswishlist = 1
            };

            Bookswishlist bookswishlist = new Bookswishlist()
            {
                User = "diecolbe",
                CreationDate = DateTime.Now,
                NumberBookswishlist = 1
            };            

            createBooksWishlistRepositoryMock.Setup(x => x.CreateBooksWishlist(It.IsAny<Bookswishlist>())).Returns(bookswishlist);

            //Act
            var result = useCase.Handle(createBookswishlistDto);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(true);

        }
    }
}
