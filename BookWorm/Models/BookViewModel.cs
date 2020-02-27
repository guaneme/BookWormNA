using BookWorm.Data.Models;
using BookWorm.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
        public List<Series> Series { get; set; }
        public Series SelectedSeries { get; set; }
        public Author SelectedAuthor { get; set; }

    }
}