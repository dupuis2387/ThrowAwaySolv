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

        public IQueryable<ShowTimeModel> ListAllShowTimes()
        {
            /*if (_userService.CurrentUser != null)
                return _context.Subscriptions
                        .Where(u => u.UserId == _userService.CurrentUser.Id)
                        .Select(u => u.Feed)
                        .Where(f => !f.IsDeleted)
                        .OrderBy(x => x.Name)
                        .ProjectTo<Feed>(_mapper.ConfigurationProvider);

            return new List<Feed>().AsQueryable();*/
            //_context.ShowTimes.S
            return null;

        }
        public IQueryable<MovieModel> ListAllMovies()
        {
            return _context
                .Movies
                //.Select(m => m)
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
