using System;
using System.Linq;
using SolvTest.Api.Data.Entities;

namespace SolvTest.Api.Data.Repositories.Concrete
{
    public interface IShowTimeRepository
    {
        IQueryable<ShowTimeEntity> GetShowTimesForMovie(Guid movieId);
    }
}
