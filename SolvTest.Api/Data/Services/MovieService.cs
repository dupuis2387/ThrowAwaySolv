using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SolvTest.Api.Data.Models;
using SolvTest.Api.Data.Repositories.Concrete;

namespace SolvTest.Api.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IShowTimeRepository _showtimeRepo;

        //i find it easier to house the mapper here rather than peppered
        //around elsewhere, like the controllers
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepo, IShowTimeRepository showTimeRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
            _showtimeRepo = showTimeRepo;
        }

        public IQueryable<MovieModel> GetMovies(string optionalMovieDescription = null)
        {

            return _movieRepo
                     .GetMovies(optionalMovieDescription)
                     .ProjectTo<MovieModel>(_mapper.ConfigurationProvider);

        }

        public bool MovieExists(Guid movieId)
        {
            if (movieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return (null != _movieRepo.MovieDetails(movieId));
        }

        public MovieModel MovieDetails(Guid movieId)
        {
            if (movieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return _mapper.Map<MovieModel>(_movieRepo.MovieDetails(movieId));

        }

        public IQueryable<ShowTimeModel> GetShowTimes(Guid movieId)
        {
            if (movieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return  _showtimeRepo
                    .GetShowTimesForMovie(movieId)
                    .OrderBy(c => c.MovieShowTime)
                    .ProjectTo<ShowTimeModel>(_mapper.ConfigurationProvider);
        }


    }
}
