using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Data.Services
{
    public class BookAuthorData
    {
        public void Add(BookAuthorData bookAuthorData)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    repository.Save(bookAuthorData);
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                }
            }

        }

        public BookAuthor Get(int id)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return (BookAuthor)repository.GetById(typeof(BookAuthor), id);
            }
            catch
            {
                throw;
            }
        }

        public BookAuthor GetByAuthorIdAndBookId(int authorId, int bookId)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<BookAuthor>().Where(ba=>ba.AuthorId == authorId && ba.BookId==bookId).SingleOrDefault();
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<BookAuthor> GetByAuthorId(int authorId)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<BookAuthor>().Where(ba => ba.AuthorId == authorId);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<BookAuthor> GetByBookId(int bookId)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<BookAuthor>().Where(ba => ba.BookId == bookId);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<BookAuthor>();
            }
            catch
            {
                throw;
            }
        }

        public void Update(BookAuthor bookAuthor)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    var existing = (BookAuthor)repository.GetById(typeof(BookAuthor), bookAuthor.BookAuthorId);
                    if (existing != null)
                    {
                        existing.AuthorId = bookAuthor.AuthorId;
                        existing.BookId = bookAuthor.BookId;
                        repository.Save(existing);
                    }
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                }
            }
        }
        public void Delete(int id)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    var bookAuthor = (BookAuthor)repository.GetById(typeof(BookAuthor), id);

                    repository.BeginTransaction();
                    repository.Delete(bookAuthor);
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                }
            }

        }

    }
}
