using System;
namespace SolvTest.Api.Data.Models
{
    public class ShowTimeModel
    {
        public Guid Id { get; set; }

        public DateTime MovieShowTime { get; set; }

        public Guid MovieId { get; set; }
    }
}
