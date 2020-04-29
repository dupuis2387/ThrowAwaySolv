using System;
using System.Collections.Generic;
using SolvTest.Api.Data.Entities;

namespace SolvTest.Api.Data.Models
{
    public class MovieModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PlaintextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri ImageUrl { get; set; }
        public ICollection<ShowTimeEntity> ShowTimes { get; set; }
    }
}
