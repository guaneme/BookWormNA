using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWorm.Data.Models
{
    public class Book
    {
        public virtual int BookId { get; set; }
        [Required]
        public virtual string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        //[Required]
        [Display(Name = "Cover Art")]
        public virtual byte[] CoverArt { get; set; }
        [Required]
        [Display(Name = "Rating")]
        public virtual RatingType Rating { get; set; }
        public virtual int SeriesId { get; set; }
        protected virtual object BookRowVersion { get; set; }
    }
}
