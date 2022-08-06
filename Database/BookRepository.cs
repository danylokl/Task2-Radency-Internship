using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class BookRepository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;
        protected DbSet<T> DbSet;

        public  BookRepository(Context context)
        {
            context.Database.EnsureDeleted();
            _context = context;
            context.Database.EnsureCreated();
            DbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await DbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await DbSet.FindAsync(id);
            return result;
        }

        public async Task<T> Create(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task Remove(int id)
        {
            var entity = await GetByIdAsync(id);
            Remove(entity);
        }
    }
}
