using System;
using System.Linq;
using SolvTest.Api.Data.Models;

namespace SolvTest.Api.Data.Services
{
    public interface IMovieService
    {
        

        /// <summary>
        /// Lists all the movies
        /// </summary>
        /// <returns></returns>
        IQueryable<MovieModel> ListAllMovies();

        /// <summary>
        /// Lists all the movies matching a search string/description
        /// or internally calls <seealso cref="ListAllMovies"/> to return everything
        /// </summary>
        /// <param name="movieDescription">a criterion for the list of movies to return matching the movieDescription search string</param>
        /// <returns>One or more movies matching the search. Or all movies, if not search string is provided.</returns>
        IQueryable<MovieModel> GetMovies(string movieDescription);
        
        /// <summary>
        /// Returns the details of a specific movie
        /// </summary>
        /// <param name="movieId">The GUID id of a given movie</param>
        /// <returns></returns>
        MovieModel MovieDetails(Guid movieId);


        /// <summary>
        /// Checks to see if given a movie's Id, it exists
        /// </summary>
        /// <param name="movieId">The GUID id of a given movie</param>
        /// <returns></returns>
        bool MovieExists(Guid movieId);

        /// <summary>
        /// Gets a list of showtimes for a given movie GUID id
        /// </summary>
        /// <param name="movieId">The GUID id of a given movie</param>
        /// <returns></returns>
        IQueryable<ShowTimeModel> GetShowTimes(Guid movieId);



    }
}
