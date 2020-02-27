using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Data.Services
{
    public class InMemoryBookData : IBookData
    {
        List<Book> books;
        public InMemoryBookData()
        {
            books = new List<Book>()
            {
                new Book {BookId=1, Title="The Lord of the Rings", Description = "One Ring to rule them all, One Ring to find them, One Ring to bring them all and in the darkness bind them",CoverArt=null, Rating=RatingType.FiveStar, SeriesId=1  },
                new Book {BookId=2, Title="Harry Potter and the Sorcerer's Stone", Description = "Turning the envelope over, his hand trembling, Harry saw a purple wax seal bearing a coat of arms; a lion, an eagle, a badger and a snake surrounding a large letter 'H'.",CoverArt=null, Rating=RatingType.FourStar, SeriesId=0  }
            };
        }

        public void Add(Book book)
        {
            books.Add(book);
            book.BookId = books.Max(b => b.BookId) + 1;
        }

        public void Delete(int id)
        {
            var book = Get(id);
            if (book != null)
            {
                books.Remove(book);
            }
        }

        public Book Get(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books.OrderBy(b => b.Title);
        }

        public void Update(Book book)
        {
            var existing = Get(book.BookId);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Description = book.Description;
                existing.Rating = book.Rating;
                existing.CoverArt = book.CoverArt;
                existing.SeriesId = book.SeriesId;
            }
        }
    }
}
