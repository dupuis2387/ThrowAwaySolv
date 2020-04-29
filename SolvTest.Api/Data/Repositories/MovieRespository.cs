using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolvTest.Api.Data.DbContexts;

namespace SolvTest.Api.Data.Repositories
{
    public class MovieRepository<TEntity, TModel> : IMovieRepository<TModel>, IDisposable
        where TEntity : class
        where TModel : class
    {



        private readonly MovieContext _movieContext;
        private readonly IMapper _mapper;


        public MovieRepository(MovieContext context,
            IMapper mapper)
        {
            _movieContext = context;
            _mapper = mapper;
        }


        public async Task<TModel> Get(Guid id)
        {
            return _mapper.Map<TModel>(await _movieContext.Set<TEntity>().FindAsync(id));
        }

        public IQueryable<TModel> List()
        {
            return _movieContext.Set<TEntity>()
                .ProjectTo<TModel>(_mapper.ConfigurationProvider);
        }

        //Todo: fix this
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }

}
