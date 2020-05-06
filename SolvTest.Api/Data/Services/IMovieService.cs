using System;
using System.Linq;
using SolvTest.Api.Data.Models;

namespace SolvTest.Api.Data.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// Get a list of movies, matching an optional passed criteria to search on
        /// </summary>
        /// <param name="movieDescription">A piece of text to try and match against a movie title or description. Omit to get back all the movies</param>
        /// <returns></returns>
        IQueryable<MovieModel> GetMovies(string optionalMovieDescription= null);

        /// <summary>
        /// Returns the details of a movie, including showtimes
        /// </summary>
        /// <param name="movieId">A valid movie GUID</param>
        /// <returns></returns>
        MovieModel MovieDetails(Guid movieId);

        /// <summary>
        /// Check to see if given a movie GUID, the movie exists
        /// </summary>
        /// <param name="movieId">A valid movie GUID</param>
        /// <returns></returns>
        bool MovieExists(Guid movieId);

        /// <summary>
        /// Gets a list of showtimes for a given movie GUID
        /// </summary>
        /// <param name="movieId">A valid movie GUID</param>
        /// <returns></returns>
        IQueryable<ShowTimeModel> GetShowTimes(Guid movieId);



    }
}
