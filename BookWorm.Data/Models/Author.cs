using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWorm.Data.Models
{
    public class Author
    {
        public virtual int AuthorId { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}
