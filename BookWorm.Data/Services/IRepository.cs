using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Text;
using System.Linq;

namespace BookWorm.Data.Services
{
public interface IRepository
    {
        void Save(object obj);
        void Delete(object obj);
        object GetById(Type objType, object objId);
        IQueryable<TEntity> ToList<TEntity>();
    }
}
