using System.ComponentModel.DataAnnotations;

namespace BookWorm.Data.Models
{
    public class Series
    {
        public virtual int SeriesId { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}