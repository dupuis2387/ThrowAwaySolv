using System;
using System.Linq;
using SolvTest.Api.Data.DbContexts;
using SolvTest.Api.Data.Entities;
using SolvTest.Api.Data.Repository;

namespace SolvTest.Api.Data.Repositories.Concrete
{   

    public class ShowTimeRepository : AbstractRepository<ShowTimeEntity>, IShowTimeRepository
    {
        public ShowTimeRepository(MovieContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<ShowTimeEntity> GetShowTimesForMovie(Guid movieId)
        {
            return base.GetFiltered(s => s.MovieId == movieId);
        }
               

    }

}
