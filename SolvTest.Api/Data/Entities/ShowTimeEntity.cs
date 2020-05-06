
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SolvTest.Api.Data.Entities
{
    [Table("MovieShowtimes")]
    public class ShowTimeEntity
    {


        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime MovieShowTime { get; set; }

        [ForeignKey("MovieId")]
        public MovieEntity Movie { get; set; }

        public Guid MovieId { get; set; }
    }

}
