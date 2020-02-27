using BookWorm.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Data.Services
{
    public interface IAuthorData
    {
        IEnumerable<Author> GetAll();
        Author Get(int id);

        void Add(Author book);
        void Update(Author book);
        void Delete(int id);
    }
}
