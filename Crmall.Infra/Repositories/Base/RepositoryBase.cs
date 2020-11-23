using CrmallTeste.Domain.Entities.Base;
using CrmallTeste.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrmallTeste.Infra.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;

        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async  Task<string> AddReturnIdAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            T existing = await GetByIdAsync(x => x.Id.Equals(entity.Id));
            if (existing != null) _context.Set<T>().Remove(existing);
        }

        public async Task<IList<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties != null)
            {
                query = includeProperties(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetByAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<T>> GetByOrderAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> order, bool descending, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null)
        {
            IQueryable<T> query;

            if (!descending)
            {
                query = _context.Set<T>().Where(predicate).OrderBy(order);
                if (includeProperties != null)
                {
                    query = includeProperties(query);
                }
            }
            else
            {
                query = _context.Set<T>().Where(predicate).OrderByDescending(order);
                if (includeProperties != null)
                {
                    query = includeProperties(query);
                }
            }


            return await query.ToListAsync();
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
