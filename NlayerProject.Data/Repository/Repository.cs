using Microsoft.EntityFrameworkCore;
using NlayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Data.Repository
{


    public class Repository<Tentiy> : IRepository<Tentiy> where Tentiy : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<Tentiy> _dbset;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<Tentiy>();
        }

        public async Task AddAsync(Tentiy entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Tentiy> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<Tentiy>> Where(Expression<Func<Tentiy, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Tentiy>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Tentiy> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(Tentiy entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Tentiy> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public Tentiy Update(Tentiy entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<Tentiy> SingleOrDefaultAsync(Expression<Func<Tentiy, bool>> predicate)
        {
            return await _dbset.SingleOrDefaultAsync(predicate);
        }
    }
}
