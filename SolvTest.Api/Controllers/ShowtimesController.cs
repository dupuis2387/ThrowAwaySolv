using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SolvTest.Api.Data.Models;
using SolvTest.Api.Data.Services;

namespace SolvTest.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/movies/{movieId}/showtimes")]
    public class ShowtimesController: ControllerBase
    {
        private readonly IMovieService _movieService;
        public ShowtimesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Gets the showtimes for a given movie, vis-a-vis a valid movie GUID
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/movies/{movieId}/showtimes
        ///     
        /// </remarks>
        /// <param name="movieId">a valid movie GUID</param>
        /// <returns>A list of 0 or more showtimes for a given movie</returns>
        /// <response code="200">Returns a list of movies</response>
        /// <response code="400">If no movie with that given id exists</response>
        [HttpGet]
        public ActionResult<IQueryable<ShowTimeModel>> GetShowtimeForMovie(Guid movieId)
        {
            if (!_movieService.MovieExists(movieId))
            {
                return NotFound();
            }

            var movieShowtimes = _movieService.GetShowTimes(movieId);
            return Ok(movieShowtimes);

        }
    }

    
}
