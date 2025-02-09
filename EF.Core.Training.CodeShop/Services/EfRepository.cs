﻿using EF.Core.Training.BlackBox;
using Microsoft.EntityFrameworkCore;

namespace EF.Core.Training
{
    /// <summary>
    /// Entity Framework Core Repository.
    /// This is where you will implement the IRepositories methods used by the Unit Tests.
    /// </summary>
    public class EfRepository : IRepository
    {
        #region Do Not Alter
        private readonly ApiContext apiContext;
        public EfRepository()
        {
            apiContext = new ApiContext();
        }
        public async Task MigrateDb()
        {
            await apiContext.Database.MigrateAsync();
        }
        #endregion

        // ALL CODE CHANGES SHOULD HAPPEN BELOW THIS COMMENT

        public Task<Author> CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorBookLink> CreateAuthorBookLink(AuthorBookLink link)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> CreateBook(Book book)
        {
            apiContext.Books.Add(book);
            await apiContext.SaveChangesAsync();
            return book;
        }

        public async Task<BookGenreLink> CreateBookGenreLink(BookGenreLink link)
        {
            apiContext.BookGenreLinks.Add(link);
            await apiContext.SaveChangesAsync();
            return link;
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            apiContext.Genres.Add(genre);
            await apiContext.SaveChangesAsync();
            return genre;
        }

        public Task<bool> DeleteAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAuthorBookLink(AuthorBookLink link)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAuthorBookLinksForBook(int bookID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBookGenreLink(BookGenreLink link)
        {
            apiContext.Remove(link);
            return await apiContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookGenreLinksForBook(int bookID)
        {
            apiContext.RemoveRange(apiContext.BookGenreLinks.Where(x => x.BookID == bookID));
            return await apiContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGenre(Genre genre)
        {
            try
            {
                await genre.DoBeforeDelete(this);
                apiContext.Genres.Remove(genre);
                return await apiContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public Task<ICollection<AuthorBookLink>> RetrieveAuthorBookLinksByAuthorID(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AuthorBookLink>> RetrieveAuthorBookLinksByBookID(int bookID)
        {
            throw new NotImplementedException();
        }

        public Task<Author> RetrieveAuthorByID(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Author>> RetrieveAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Author>> RetrieveAuthorsByBookID(int bookID)
        {
            throw new NotImplementedException();
        }

        public Task<Book> RetrieveBookByID(int bookID)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<BookGenreLink>> RetrieveBookGenreLinksByBookID(int bookID)
        {
            return await apiContext.BookGenreLinks.Where(x => x.BookID == bookID).ToListAsync();
        }

        public Task<ICollection<Book>> RetrieveBooks()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> RetrieveBooksByAuthorID(int authorID)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> RetrieveBooksByGenreID(int genreID)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> RetrieveGenreByID(int genreID)
        {
            return await apiContext.Genres.FirstOrDefaultAsync(x => x.ID == genreID);
        }

        public async Task<ICollection<Genre>> RetrieveGenres()
        {
            return await apiContext.Genres.ToListAsync();
        }

        public async Task<ICollection<Genre>> RetrieveGenresByBookID(int bookID)
        {
            return await apiContext.Genres.Include(x => x.BookLinks)
                .Where(x => x.BookLinks.Any(l => l.BookID == bookID)).ToListAsync();
        }

        public Task<Author> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> UpdateGenre(Genre genre)
        {
            apiContext.Genres.Update(genre);
            await apiContext.SaveChangesAsync();

            return genre;
        }
    }
}
