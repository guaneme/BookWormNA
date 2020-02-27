using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Data.Services
{
    public class AuthorData : IAuthorData
    {
        public void Add(Author author)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    repository.Save(author);
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                    //Exception handling wasn't competently implemented I would use maybe Log4Net to handle the exceptions
                }
            }

        }

        public Author Get(int id)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return (Author)repository.GetById(typeof(Author), id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<Author>();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Author author)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    var existing = (Author)repository.GetById(typeof(Author), author.AuthorId);
                    if (existing != null)
                    {
                        existing.Name = author.Name;
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
                    var author = (Author)repository.GetById(typeof(Author), id);

                    repository.BeginTransaction();
                    repository.Delete(author);
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
