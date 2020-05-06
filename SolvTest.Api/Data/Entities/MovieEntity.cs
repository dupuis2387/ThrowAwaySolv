
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SolvTest.Api.Data.Entities
{
    public class MovieEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string PlaintextDescription { get; set; }

        [Required]
        [MaxLength(1000)]
        [DataType(DataType.Html)]
        public string HtmlDescription { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ArtUrl { get; set; }



        /// <summary>
        /// A Movie can have 0 or more show times
        /// </summary>        
        public ICollection<ShowTimeEntity> ShowTimes { get; set; }
        = new List<ShowTimeEntity>();

    }
}
