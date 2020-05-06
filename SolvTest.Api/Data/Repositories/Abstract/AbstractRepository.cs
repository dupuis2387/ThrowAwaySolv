using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SolvTest.Api.Data.DbContexts;
//using System.Data.Entity.Infrastructure;

namespace SolvTest.Api.Data.Repository
{
    /// <summary>
    /// Abstract class that should be inherited from, as a blueprint for a Factory pattern
    /// Members are virtual to allow derived classes to override these base methods
    /// and add additional concrete logic that makes sense to the domain object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractRepository<T> : IRepository<T>
        where T : class
    {
        protected MovieContext _dbContext;

        public AbstractRepository(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetSingle(Guid entityId)
        {
            return _dbContext.Find<T>(entityId);
        }
        
        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> searchFilter)
        {
            return _dbContext.Set<T>()
                .AsQueryable()
                .Where(searchFilter);


        }
    }
}
