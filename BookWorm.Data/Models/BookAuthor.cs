using System;
using System.Collections.Generic;
using System.Text;

namespace BookWorm.Data.Models
{
    public class BookAuthor
    {
        public virtual int BookAuthorId { get; set; }
        public virtual int BookId { get; set; }
        public virtual int AuthorId { get; set; }

    }
}
