﻿using BookWorm.Data.Models;
using BookWorm.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArtPath { get; set; }
        public RatingType Rating { get; set; }
        public string Series { get; set; }
        public string Authors { get; set; }
    }
}