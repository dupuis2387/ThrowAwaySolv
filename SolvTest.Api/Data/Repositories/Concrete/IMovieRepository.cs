using System;
using System.Linq;
using SolvTest.Api.Data.Entities;

namespace SolvTest.Api.Data.Repositories.Concrete
{
    public interface IMovieRepository
    {
        IQueryable<MovieEntity> GetMovies(string partialMovieDescription = null, bool includeShowTimes = false);
        MovieEntity MovieDetails(Guid movieId);

    }
}
