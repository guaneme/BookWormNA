using BookWorm.Data.Models;
using BookWorm.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.IoC
{

    public class RepositoryFactory
    {
        //I would use a dependency injection framework here. For simplicity, doing it manually.

        public static IAuthorData CreateAuthorDataRepository()
        {
            return new FakeAuthorData();
            //return new AuthorData();
        }

        public static IBookData CreateBookDataRepository()
        {
            return new FakeBookData();
            //return new BookData;
        }

        public static ISeriesData CreateSeriesDataRepository()
        {
            return new FakeSeriesData();
            //return new SeriesData();
        }

        public static IBookAuthorData CreateBookAuthorDataRepository()
        {
            return new FakeBookAuthorData();
        }
    }
}