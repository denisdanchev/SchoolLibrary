﻿using SchoolLibrary.Core.Enumerations;
using SchoolLibrary.Core.Models.Book;

namespace SchoolLibrary.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookGenreServiceModel>> AllGenresAsync();

        Task<bool> GenreExistAsync(int genreId);

        Task<int> CreateAsyc(BookFormModel model, int authorId);

        Task<BookQueryServiceModel> AllAsync(
            string? genre = null,
            string? searchedTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 1);

        Task<IEnumerable<string>> AllGenresNamesAsync();

        Task<IEnumerable<BookServiceModel>> AllBooksByAuthorId(int authorId);
        Task<IEnumerable<BookServiceModel>> AllBooksByUserId(string userId);

        Task<bool> ExistsAsync(int id);
        Task<BookDetailsServiceModel> BookDetailsByIdAsync(int id);

    }
}
