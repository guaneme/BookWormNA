using BookWorm.Data.Models;
using BookWorm.Data.Services;
using BookWorm.IoC;
using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.Services
{
    public interface IBookService
    {
        BookViewModel GetDetails(int id);
        BookEditViewModel GetForEdit(int id);
        List<BookViewModel> GetList();
        void SaveOrUpdate(BookEditViewModel bookModel);
        void Delete(int id);
    }

    public class BookService : IBookService
    {
        private IBookData bookRepository;
        private ISeriesData seriesRepository;
        private IAuthorData authorRepository;
        private IBookAuthorData bookAuthorRepository;

        public BookService(IBookData _bookRepository, ISeriesData _seriesRepository, IAuthorData _authorRepository, IBookAuthorData _bookAuthorRepository)
        {
            this.bookRepository = _bookRepository;
            this.seriesRepository = _seriesRepository;
            this.authorRepository = _authorRepository;
            this.bookAuthorRepository = _bookAuthorRepository;
        }

        public void Delete(int id)
        {
            this.bookAuthorRepository.Delete(id);
            this.bookRepository.Delete(id);
        }

        public BookViewModel GetDetails(int id)
        {
            var book = this.bookRepository.Get(id);
            var series = this.seriesRepository.GetAll();
            var authors = this.authorRepository.GetAll();
            var seriesName = book.SeriesId != 0 ? series.Single(s => s.SeriesId == book.SeriesId).Name : string.Empty;
            var bookAuthors = this.bookAuthorRepository.GetAll();
            var authorsNames = from Author a in authors
                               join BookAuthor ba in bookAuthors
                               on a.AuthorId equals ba.AuthorId
                               where ba.BookId == book.BookId
                               select a.Name;

            return new BookViewModel()
            {
                ID = book.BookId,
                ArtPath = null,
                Authors = String.Join(", ", authorsNames),
                Description = book.Description,
                Rating = book.Rating,
                Series = seriesName,
                Title = book.Title
            };
        }

        public BookEditViewModel GetForEdit(int id)
        {
            var book = this.bookRepository.Get(id);
            var availableSeries = this.seriesRepository.GetAll();
            var availableAuthors = this.authorRepository.GetAll();
            var bookAuthors = this.bookAuthorRepository.GetByBookId(id);

            return new BookEditViewModel()
            {
                ArtPath = null,
                AuthorsIDs = bookAuthors.Select(ba => ba.AuthorId).ToList(),
                AvailableAuthors = availableAuthors,
                Description = book.Description,
                Rating = book.Rating,
                SeriesID = book.SeriesId,
                AvailableSeries = availableSeries,
                Title = book.Title
            };
        }

        public List<BookViewModel> GetList()
        {
            var books = this.bookRepository.GetAll();
            var series = this.seriesRepository.GetAll();
            var authors = this.authorRepository.GetAll();
            var bookAuthors = this.bookAuthorRepository.GetAll();
            List<BookViewModel> returnList = new List<BookViewModel>();

            foreach (var book in books)
            {
                var seriesName = book.SeriesId != 0 ? series.Single(s => s.SeriesId == book.SeriesId).Name : string.Empty;
                var authorsNames = from Author a in authors
                               join BookAuthor ba in bookAuthors
                               on a.AuthorId equals ba.AuthorId
                               where ba.BookId == book.BookId
                               select a.Name;

                returnList.Add(new BookViewModel()
                {
                    ID = book.BookId,
                    ArtPath = null,
                    Authors = String.Join(", ", authorsNames),
                    Description = book.Description,
                    Rating = book.Rating,
                    Series = seriesName,
                    Title = book.Title
                });
            }

            return returnList;
        }

        public void SaveOrUpdate(BookEditViewModel bookModel)
        {
            throw new NotImplementedException();
        }
    }
}