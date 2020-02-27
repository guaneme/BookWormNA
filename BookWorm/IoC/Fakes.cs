using BookWorm.Data.Models;
using BookWorm.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.IoC
{
    public class FakeAuthorData : IAuthorData
    {
        List<Author> authors = null;

        public FakeAuthorData()
        {
            this.authors = new List<Author>();

            this.authors.Add(new Author() { AuthorId = 1, Name = "Natan Aronov" });
            this.authors.Add(new Author() { AuthorId = 2, Name = "Carlos Guaneme" });

        }
        public void Add(Author book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            if (this.authors.Count(a => a.AuthorId == id) > 0)
            {
                return this.authors.Single(a => a.AuthorId == id);
            }
            return null;
        }

        public IEnumerable<Author> GetAll()
        {
            return this.authors;
        }

        public void Update(Author book)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeSeriesData : ISeriesData
    {
        private List<Series> series = null;

        public FakeSeriesData()
        {
            this.series = new List<Series>();

            this.series.Add(new Series() { SeriesId = 1, Name = "Lord of the Rings", Description = "Lord of the rings" });
            this.series.Add(new Series() { SeriesId = 2, Name = "Star wars", Description = "Star Wars" });
        }
        public void Add(Series book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Series Get(int id)
        {
            if (this.series.Count(a => a.SeriesId == id) > 0)
            {
                return this.series.Single(a => a.SeriesId == id);
            }
            return null;
        }

        public IEnumerable<Series> GetAll()
        {
            return this.series;
        }

        public void Update(Series book)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeBookData : IBookData
    {
        private List<Book> books;

        public FakeBookData()
        {
            this.books = new List<Book>();

            this.books.Add(new Book() { BookId = 1, Description = "The lord of the rings 1 description", Rating = RatingType.TreeStar, SeriesId = 1, Title = "The lord of the rings 1" });
            this.books.Add(new Book() { BookId = 2, Description = "The lord of the rings 2 description", Rating = RatingType.FourStar, SeriesId = 1, Title = "The lord of the rings 2" });
            this.books.Add(new Book() { BookId = 3, Description = "The lord of the rings 4 description", Rating = RatingType.FiveStar, SeriesId = 1, Title = "The lord of the rings 3" });
            this.books.Add(new Book() { BookId = 4, Description = "Joker description", Rating = RatingType.FourStar, SeriesId = 1, Title = "Joker" });
        }
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            if (this.books.Count(b => b.BookId == id) > 0)
            {
                return this.books.Single(b => b.BookId == id);
            }
            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            return this.books;
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeBookAuthorData : IBookAuthorData
    {
        private List<BookAuthor> bookAuthors;

        public FakeBookAuthorData()
        {
            this.bookAuthors = new List<BookAuthor>();

            this.bookAuthors.Add(new BookAuthor() { AuthorId = 1, BookId = 1, BookAuthorId = 1 });
            this.bookAuthors.Add(new BookAuthor() { AuthorId = 1, BookId = 2, BookAuthorId = 2 });
            this.bookAuthors.Add(new BookAuthor() { AuthorId = 1, BookId = 3, BookAuthorId = 3 });
            this.bookAuthors.Add(new BookAuthor() { AuthorId = 1, BookId = 4, BookAuthorId = 4 });
            this.bookAuthors.Add(new BookAuthor() { AuthorId = 2, BookId = 4, BookAuthorId = 5 });
        }
        public void Add(BookAuthorData bookAuthorData)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BookAuthor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return this.bookAuthors;
        }

        public IEnumerable<BookAuthor> GetByAuthorId(int authorId)
        {
            return this.bookAuthors.Where(ba => ba.AuthorId == authorId);
        }

        public BookAuthor GetByAuthorIdAndBookId(int authorId, int bookId)
        {
            return this.bookAuthors.Single(ba => ba.AuthorId == authorId && ba.BookId == bookId);
        }

        public IEnumerable<BookAuthor> GetByBookId(int bookId)
        {
            return this.bookAuthors.Where(ba => ba.BookId == bookId);
        }

        public void Update(BookAuthor bookAuthor)
        {
            throw new NotImplementedException();
        }
    }
}