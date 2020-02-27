using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Data.Services
{
    public class BookData : IBookData
    {
        public void Add(Book book)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    repository.Save(book);
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                    //Exception handling wasn't competently implemented I would use maybe Log4Net to handle the exceptions
                }
            }

        }

        public Book Get(int id)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return (Book)repository.GetById(typeof(Book), id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Book> GetBooksbySeriesId(int seriesId)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<Book>().Where(ba => ba.SeriesId == seriesId);
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<Book> GetAll()
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<Book>();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Book book)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    var existing = (Book)repository.GetById(typeof(Book), book.BookId);
                    if (existing != null)
                    {
                        existing.Title = book.Title;
                        existing.Description = book.Description;
                        existing.Rating = book.Rating;
                        existing.CoverArt = book.CoverArt;
                        existing.SeriesId = book.SeriesId;
                        repository.Save(existing);
                    }
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                    //Exception handling wasn't competently implemented I would use maybe Log4Net to handle the exceptions
                }
            }
        }
        public void Delete(int id)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    var book = (Book)repository.GetById(typeof(Book), id);

                    repository.BeginTransaction();
                    repository.Delete(book);
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
