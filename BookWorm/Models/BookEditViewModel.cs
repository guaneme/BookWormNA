using BookWorm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.Models
{
    public class BookEditViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArtPath { get; set; }
        public RatingType Rating { get; set; }
        public int SeriesID { get; set; }
        public IEnumerable<Series> AvailableSeries { get; set; }
        public List<int> AuthorsIDs { get; set; }
        public IEnumerable<Author> AvailableAuthors { get; set; }
    }
}