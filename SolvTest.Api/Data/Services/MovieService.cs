using System;
using System.Linq;
using AutoMapper;
using SolvTest.Api.Data.DbContexts;
using SolvTest.Api.Data.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace SolvTest.Api.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieContext _context;

        //i find it easier to house the mapper here rather than peppered
        //around elsewhere, like the controllers
        private readonly IMapper _mapper;

        public MovieService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<MovieModel> GetMovies(string movieDescription)
        {
            //if nothing was passed in, return all
            //obviously wouldn't do this in production
            if (string.IsNullOrEmpty(movieDescription))
            {
                return ListAllMovies();
            }

            movieDescription = movieDescription.Trim();


            //lazy sql like. more efficient way to do it, but no time.
            return _context
                .Movies
                .Where(
                    m => EF.Functions.Like(m.Title, $"%{ movieDescription }%")
                    || EF.Functions.Like(m.PlaintextDescription, $"%{ movieDescription }%")
                    || EF.Functions.Like(m.HtmlDescription, $"%{ movieDescription }%")
                )
                .ProjectTo<MovieModel>(_mapper.ConfigurationProvider);

        }

        public IQueryable<MovieModel> ListAllMovies()
        {
            return _context
                .Movies
                .ProjectTo<MovieModel>(_mapper.ConfigurationProvider);
        }

        public bool MovieExists(Guid movieId)
        {
            if(movieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return _context.Movies.Any(m => m.Id == movieId);
        }

        public MovieModel MovieDetails(Guid movieId)
        {
            return _context
                .Movies
                .Where(m => m.Id == movieId)
                .ProjectTo<MovieModel>(_mapper.ConfigurationProvider)
                .SingleOrDefault();
        }
        
        public IQueryable<ShowTimeModel> GetShowTimes(Guid movieId)
        {
            if (movieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return _context.ShowTimes
                        .Where(s => s.MovieId == movieId)
                        .OrderBy(c => c.MovieShowTime)
                        .ProjectTo<ShowTimeModel>(_mapper.ConfigurationProvider);
        }


    }
}
