using _253502_Melikava.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.Persistence.Repository
{
    public class EfRepository<T>: IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;
        public EfRepository(AppDbContext context) 
        {
            _context = context;
            _entities = context.Set<T>();
           
        }
        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().AddAsync(entity, cancellationToken);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _entities;
            if (filter != null)
            {
                query=query.Where(filter);
            }
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T> query = _entities.AsQueryable();
            if (id >= 0)
            {
                query=query.Where(entity=>entity.Id == id);
            }
            if (includesProperties.Any())
            {
                foreach (var property in includesProperties)
                {
                    query = query.Include(property);
                }
            }
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T>? query=_entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach(Expression<Func<T,object>> included in includesProperties)
                {
                    query=query.Include(included);
                }
            }
            if(filter!= null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
