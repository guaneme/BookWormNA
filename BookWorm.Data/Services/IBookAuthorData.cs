using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Data.Services
{
    public interface IBookAuthorData
    {
        void Add(BookAuthorData bookAuthorData);
        BookAuthor Get(int id);
        BookAuthor GetByAuthorIdAndBookId(int authorId, int bookId);
        IEnumerable<BookAuthor> GetByAuthorId(int authorId);
        IEnumerable<BookAuthor> GetByBookId(int bookId);
        IEnumerable<BookAuthor> GetAll();
        void Update(BookAuthor bookAuthor);
        void Delete(int id);
    }
}
