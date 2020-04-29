using System;
using System.Linq;
using System.Threading.Tasks;
namespace SolvTest.Api.Data.Repositories
{
    public interface IMovieRepository<TModel>
    {
        IQueryable<TModel> List();
        Task<TModel> Get(Guid id);

    }
}
