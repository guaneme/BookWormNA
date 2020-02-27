using BookWorm.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Data.Services
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);

        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
