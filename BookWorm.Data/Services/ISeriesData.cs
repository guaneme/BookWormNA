using BookWorm.Data.Models;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Data.Services
{
    public interface ISeriesData
    {
        IEnumerable<Series> GetAll();
        Series Get(int id);

        void Add(Series book);
        void Update(Series book);
        void Delete(int id);
    }
}
