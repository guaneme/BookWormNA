using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm.Data.Services
{
    public class SeriesData : ISeriesData
    {
        public void Add(Series series)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    repository.Save(series);
                }
                catch
                {
                    repository.RollbackTransaction();
                    throw;
                    //Exception handling wasn't competently implemented I would use maybe Log4Net to handle the exceptions
                }
            }

        }

        public Series Get(int id)
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return (Series)repository.GetById(typeof(Series), id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Series> GetAll()
        {
            RepositoryBase repository = new RepositoryBase();
            try
            {
                return repository.ToList<Series>();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Series series)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    var existing = (Series)repository.GetById(typeof(Series), series.SeriesId);
                    if (existing != null)
                    {
                        existing.Name = series.Name;
                        existing.Description = series.Description;
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
                    var series = (Series)repository.GetById(typeof(Series), id);

                    repository.BeginTransaction();
                    repository.Delete(series);
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
