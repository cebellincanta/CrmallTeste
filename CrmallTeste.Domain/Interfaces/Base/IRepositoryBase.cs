using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrmallTeste.Domain.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
        Task<IList<T>> GetByAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
        Task<IList<T>> GetByOrderAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> order, bool descending, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
        Task AddAsync(T entity);
        Task<string> AddReturnIdAsync(T entity);
        Task DeleteAsync(T entity);
        T Update(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
    }
}