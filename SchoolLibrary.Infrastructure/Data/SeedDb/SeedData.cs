using Microsoft.AspNetCore.Identity;
using SchoolLibrary.Infrastructure.Data.Models;
using static System.Net.WebRequestMethods;

namespace SchoolLibrary.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {

        public IdentityUser AuthorUser { get; set; }
        public IdentityUser GuestUser { get; set; }

        public Author Author { get; set; }

        public Genre FantasyGenre { get; set; }
        public Genre HorrorGenre { get; set; }
        public Genre RomanticGenre { get; set; }
        public Genre HistoryGenre { get; set; }
        public Genre MysteryGenre { get; set; }

        public Book FirstBook { get; set; }
        public Book SecondBook { get; set; }
        public Book ThirdBook { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAuthor();
            SeedGenres();
            SeedBooks();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AuthorUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "author@mail.com",
                NormalizedUserName = "author@mail.com",
                Email = "author@mail.com",
                NormalizedEmail = "author@mail.com"
            };

            AuthorUser.PasswordHash =
                 hasher.HashPassword(AuthorUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AuthorUser, "guest123");
        }

        private void SeedAuthor()
        {
            Author = new Author()
            {
                Id = 1,
                AuthorName = "Bram Stoker",
                UserId = AuthorUser.Id
            };
        }

        private void SeedGenres()
        {
            FantasyGenre = new Genre()
            {
                Id = 1,
                GenreName = "Fantasy"
            };

            HorrorGenre = new Genre()
            {
                Id = 2,
                GenreName = "Horror"
            };

            RomanticGenre = new Genre()
            {
                Id = 3,
                GenreName = "Romantic"
            };

            HistoryGenre = new Genre()
            {
                Id = 4,
                GenreName = "History"
            };

            MysteryGenre = new Genre()
            {
                Id = 5,
                GenreName = "Mystery"
            };
        }

        private void SeedBooks()
        {
            FirstBook = new Book()
            {
                Id = 1,
                BookTitle = "Dracula",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1387151694i/17245.jpg",
                BookPages = 180,
                PositionInLibrary = "2C",
                Description = "Jonathan Harker visits Transylvania to help Count Dracula with the purchase of a London house",
                GenreId = HorrorGenre.Id,
                AuthorId = Author.Id,
                TakerId = GuestUser.Id
            };

            SecondBook = new Book()
            {
                Id = 2,
                BookTitle = "The Lady of the Shroud",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347813983i/35820.jpg",
                BookPages = 120,
                PositionInLibrary = "1G",
                Description = "Some intereseing book to read.",
                GenreId = RomanticGenre.Id,
                AuthorId = Author.Id,
            };

            ThirdBook = new Book()
            {
                Id = 3,
                BookTitle = "The Man",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347816010i/6363980.jpg",
                BookPages = 160,
                PositionInLibrary = "3C",
                Description = "Squire Stephen Norman is lord of the manor in Normanstead.",
                GenreId = HorrorGenre.Id,
                AuthorId = Author.Id,
            };
        }

    }
}
