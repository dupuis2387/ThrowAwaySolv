using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SolvTest.Api.Data.Models;
using SolvTest.Api.Data.Services;

namespace SolvTest.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        /// <summary>
        /// Get a listing of movies, taking into account an optional search parameter
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/movies
        ///     
        /// </remarks>
        /// <param name="movieDescription">An optional search param. If empty, all movies come back</param>
        /// <returns>The listing of all the movies</returns>
        /// <response code="200">Returns a list of movies</response>
        [HttpGet()]
        public ActionResult<IQueryable<MovieModel>> GetMovies(
            [FromQuery] string movieDescription)
        {
            var movieList = _movieService.GetMovies(movieDescription);
            return Ok(movieList);
        }

        /// <summary>
        /// Gets the details of a specific movie, given a movie's valid GUID movie id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/movies/{movieId}
        /// 
        /// </remarks>
        /// <param name="movieId">a valid GUID movie id</param>
        /// <returns>The details of a specific movie</returns>
        /// <response code="200">Returns the details of a movie</response>
        /// <response code="400">If no movie with that given id exists</response>
        [HttpGet("{movieId:guid}")]
        public ActionResult<MovieModel> GetMovie(Guid movieId)
        {            
            var movie = _movieService.MovieDetails(movieId);
            if (null == movie)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}
