using System;
using System.Linq;
using System.Linq.Expressions;

namespace SolvTest.Api.Data.Repository
{
    public interface IRepository<T>
    {
        T GetSingle(Guid entityId);
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> searchFilter);
        IQueryable<T> GetAll();        

    }
}
