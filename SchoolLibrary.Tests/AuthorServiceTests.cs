using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Services;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data;
using SchoolLibrary.Infrastructure.Data.Models;
using System.Drawing.Text;
using System.Linq;


namespace SchoolLibrary.Tests
{
    [TestFixture]
    public class AuthorServiceTests
    {
        private IEnumerable<Author> authors;
        private SchoolLibraryDbContext dbContext;
        private IRepository repository;

        [SetUp]
        public void TestInitialize()
        {
            this.authors = new List<Author>()
            {
                new Author { Id = 1,AuthorName = "Anton Dechev"},
                new Author { Id = 2,AuthorName = "Dicho Tilev"},
                new Author { Id = 3,AuthorName = "Monko Penev"},
            };



            var options = new DbContextOptionsBuilder<SchoolLibraryDbContext>()
                    .UseInMemoryDatabase(databaseName: "SchoolLibraryMemoryDb")
                    .Options;
            this.dbContext = new SchoolLibraryDbContext(options);
            this.dbContext.AddRange(this.authors);
            this.dbContext.SaveChanges();

            Mock<IRepository> mockRepository = new Mock<IRepository>();

            Author newAuthor = new Author()
            {
                Id=4,
                AuthorName = "Petko Penev"
            };

            mockRepository.Setup(r => r.AddAsync(newAuthor));
            int repoCount = mockRepository.Setup(t => t.Query());
        }
        
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void AuthorCreate()
        {
            IAuthorService service = new AuthorService(repository);
            service.
            Assert.Pass();
        }
    }
}