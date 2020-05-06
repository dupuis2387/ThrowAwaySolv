using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SolvTest.Api.Data.DbContexts;
using SolvTest.Api.Data.Entities;
using SolvTest.Api.Data.Repository;

namespace SolvTest.Api.Data.Repositories.Concrete
{

    public class MovieRepository : AbstractRepository<MovieEntity>, IMovieRepository
    {
        public MovieRepository(MovieContext dbContext)
            : base(dbContext)
        {
        }

        public MovieEntity MovieDetails(Guid movieId)
        {
            if (movieId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(movieId));
            }
            return  base
                    ._dbContext
                    .Movies
                    .AsNoTracking()
                    .Include(m=>m.ShowTimes)
                    .Single(m => m.Id == movieId);
        }

        
        public IQueryable<MovieEntity> GetMovies(string partialMovieDescription = null, bool includeShowTimes = false)
        {
            if (string.IsNullOrEmpty(partialMovieDescription))
            {
                return base.GetAll();
            }

            partialMovieDescription = partialMovieDescription.Trim();

            //needlessly flexing. but some people love seeing complex code for the sake of complexity. (i am not one of those people)
            Expression<Func<MovieEntity, bool>> filterLikeExpression = m => (
                EF.Functions.Like(m.Title, $"%{ partialMovieDescription }%")
                || EF.Functions.Like(m.PlaintextDescription, $"%{ partialMovieDescription }%")
                || EF.Functions.Like(m.HtmlDescription, $"%{ partialMovieDescription }%")
            );

            if (!includeShowTimes)
            {
                return base.GetFiltered(filterLikeExpression);
            }
            else
            {
                return  base
                        .GetAll()
                        .Include(m => m.ShowTimes)
                        .Where(filterLikeExpression);
            }




        }
    }
}
