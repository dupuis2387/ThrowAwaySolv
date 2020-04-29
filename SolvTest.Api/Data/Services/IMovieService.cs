using System;
using System.Linq;
using SolvTest.Api.Data.Models;

namespace SolvTest.Api.Data.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// List the user feeds
        /// </summary>
        /// <returns></returns>
        IQueryable<ShowTimeModel> ListAllShowTimes();

        /// <summary>
        /// List All the feeds
        /// </summary>
        /// <returns></returns>
        IQueryable<MovieModel> ListAllMovies();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <returns></returns>
        IQueryable<MovieModel> GetMovies(string movieDescription);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        MovieModel MovieDetails(Guid movieId);


        /// <summary>
        /// If we had full CRUD operations, this could also be used a check to make sure we
        /// didn't try to re-create the same movie, and avoid yucky errors
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        bool MovieExists(Guid movieId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        IQueryable<ShowTimeModel> GetShowTimes(Guid movieId);



    }
}
